using Caliburn.Micro;
using WindowResizer.Events;

namespace WindowResizer.ViewModels
{
    public class ShellViewModel : Screen, IShell, IHandle<WindowSizeChangeEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;

            _eventAggregator.Subscribe(this);
        }

        private int _width = 300;

        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
                NotifyOfPropertyChange(() => Dimensions);
            }
        }

        private int _height = 300;

        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                NotifyOfPropertyChange(() => Height);
                NotifyOfPropertyChange(() => Dimensions);
            }
        }

        private string _dimensions;

        public string Dimensions
        {
            get { return $"{Width} * {Height}"; }
        }

        public void Handle(WindowSizeChangeEvent message)
        {
            Width = message.Width;
            Height = message.Height;
        }

        public void OpenChildWindow()
        {
            _windowManager.ShowDialog(new ChildWindowViewModel(_eventAggregator));
        }
    }
}