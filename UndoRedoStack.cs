using ImageMagick;
using System.Collections.Generic;
using System.Linq;

namespace OpenGifImage
{
    public class UndoRedoStack
    {
        private readonly List<MagickImageCollection> _undo = new List<MagickImageCollection>();
        private readonly List<MagickImageCollection> _redo = new List<MagickImageCollection>();
        private const int MaxHistory = 10;

        public bool CanUndo => _undo.Count > 0;
        public bool CanRedo => _redo.Count > 0;

        public void PushState(MagickImageCollection state)
        {
            _undo.Add((MagickImageCollection)state.Clone());
            foreach (var item in _redo) item.Dispose();
            _redo.Clear();
            if (_undo.Count > MaxHistory)
            {
                _undo[0].Dispose(); 
                _undo.RemoveAt(0);
            }
        }

        public MagickImageCollection Undo(MagickImageCollection currentState)
        {
            if (!CanUndo) return currentState;

            _redo.Add((MagickImageCollection)currentState.Clone());
            var previousState = _undo.Last();
            _undo.RemoveAt(_undo.Count - 1);

            return previousState;
        }

        public MagickImageCollection Redo(MagickImageCollection currentState)
        {
            if (!CanRedo) return currentState;

            _undo.Add((MagickImageCollection)currentState.Clone());
            var nextState = _redo.Last();
            _redo.RemoveAt(_redo.Count - 1);

            return nextState;
        }

        public void Clear()
        {
            foreach (var item in _undo) item.Dispose();
            foreach (var item in _redo) item.Dispose();
            _undo.Clear();
            _redo.Clear();
        }
    }
}