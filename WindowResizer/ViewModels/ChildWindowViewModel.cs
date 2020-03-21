using Caliburn.Micro;
using WindowResizer.EventModels;

namespace WindowResizer.ViewModels
{
    public class ChildWindowViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        public ChildWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private int _width = 300;

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                _eventAggregator.PublishOnUIThread(new WindowSizeChangeEvent() { Width = Width, Height = Height });
            }
        }
     
        private int _height = 300;

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                _eventAggregator.PublishOnUIThread(new WindowSizeChangeEvent() { Width = Width, Height = Height });
            }
        }
    }
}
