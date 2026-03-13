using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OpenGifImage
{
    public class GifImage : IDisposable
    {
        private MagickImageCollection _collection;
        private readonly Stack<MagickImageCollection> _undoStack = new Stack<MagickImageCollection>();
        private readonly Stack<MagickImageCollection> _redoStack = new Stack<MagickImageCollection>();
        private readonly object _syncRoot = new object();
        private const int MaxStackSize = 10;

        public int FramesCount => _collection?.Count ?? 0;
        public int Width => (_collection?.Count > 0) ? (int)_collection[0].Width : 0;
        public int Height => (_collection?.Count > 0) ? (int)_collection[0].Height : 0;
        public bool CanUndo => _undoStack.Count > 0;
        public bool CanRedo => _redoStack.Count > 0;

        public GifImage(string path)
        {
            _collection = new MagickImageCollection(path);
            _collection.Coalesce();
        }

        public IMagickImage<byte> GetFrame(int index)
        {
            lock (_syncRoot)
            {
                if (index < 0 || index >= _collection.Count) throw new ArgumentOutOfRangeException(nameof(index));
                return _collection[index];
            }
        }

        private MagickImageCollection CloneCollection(MagickImageCollection source)
        {
            var copy = new MagickImageCollection();
            foreach (var frame in source) copy.Add(new MagickImage(frame));
            return copy;
        }

        public void SaveState()
        {
            lock (_syncRoot)
            {
                _undoStack.Push(CloneCollection(_collection));
                while (_redoStack.Count > 0) _redoStack.Pop().Dispose();
                if (_undoStack.Count > MaxStackSize)
                {
                    var list = _undoStack.ToList();
                    list.Last().Dispose();
                    _undoStack.Clear();
                    for (int i = list.Count - 2; i >= 0; i--) _undoStack.Push(list[i]);
                }
            }
        }

        public void Undo()
        {
            lock (_syncRoot)
            {
                if (!CanUndo) return;
                _redoStack.Push(CloneCollection(_collection));
                _collection.Dispose();
                _collection = _undoStack.Pop();
            }
        }

        public void Redo()
        {
            lock (_syncRoot)
            {
                if (!CanRedo) return;
                _undoStack.Push(CloneCollection(_collection));
                _collection.Dispose();
                _collection = _redoStack.Pop();
            }
        }

        public void Crop(Rectangle rect)
        {
            lock (_syncRoot)
            {
                var geometry = new MagickGeometry(rect.X, rect.Y, (uint)Math.Max(1, rect.Width), (uint)Math.Max(1, rect.Height));
                foreach (var frame in _collection)
                {
                    frame.Crop(geometry);
                    frame.Page = new MagickGeometry(0, 0, geometry.Width, geometry.Height);
                }
            }
        }

        public void CropLength(int start, int end)
        {
            lock (_syncRoot)
            {
                var newCollection = new MagickImageCollection();
                for (int i = 0; i < _collection.Count; i++)
                {
                    if (i >= start && i <= end) newCollection.Add(new MagickImage(_collection[i]));
                }
                _collection.Dispose();
                _collection = newCollection;
            }
        }

        public void AddFrame(string imagePath, int insertAfterIndex)
        {
            lock (_syncRoot)
            {
                using (var source = new MagickImageCollection(imagePath))
                {
                    source.Coalesce();
                    int pos = Math.Max(0, Math.Min(insertAfterIndex + 1, _collection.Count));
                    foreach (var f in source)
                    {
                        var clone = (MagickImage)f.Clone();
                        clone.Resize((uint)Width, (uint)Height);
                        clone.AnimationDelay = 10;
                        _collection.Insert(pos++, clone);
                    }
                }
            }
        }

        public void UpdateFrameDelays(int[] delaysMs)
        {
            lock (_syncRoot)
            {
                for (int i = 0; i < Math.Min(delaysMs.Length, _collection.Count); i++)
                    _collection[i].AnimationDelay = (uint)Math.Max(1, delaysMs[i] / 10);
            }
        }

        public void Save(string path)
        {
            lock (_syncRoot) { _collection.OptimizeTransparency(); _collection.Write(path); }
        }

        public MagickImageCollection GetCollectionForPreview()
        {
            lock (_syncRoot) return CloneCollection(_collection);
        }

        public void Dispose()
        {
            _collection?.Dispose();
            while (_undoStack.Count > 0) _undoStack.Pop().Dispose();
            while (_redoStack.Count > 0) _redoStack.Pop().Dispose();
        }
    }
}