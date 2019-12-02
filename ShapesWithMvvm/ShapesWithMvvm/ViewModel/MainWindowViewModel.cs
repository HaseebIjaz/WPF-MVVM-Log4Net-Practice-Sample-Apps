using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ShapesWithMvvm.BaseClasses;

namespace ShapesWithMvvm.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public String CursorScreenCoordiante
        {
            get
            {
                return System.Windows.Forms.Cursor.Position.ToString();
                OnPropertyChanged("CursorScreenCoordiante");
            }
        }



        protected ObservableCollection<Line> lines = new ObservableCollection<Line>();
        protected ObservableCollection<Rectangle> rectangles = new ObservableCollection<Rectangle>();
        protected ObservableCollection<Ellipse> circles = new ObservableCollection<Ellipse>();
        protected ObservableCollection<Polygon> polygons = new ObservableCollection<Polygon>();
        protected ObservableCollection<Polyline> polylines = new ObservableCollection<Polyline>();
        protected CompositeCollection collection = new CompositeCollection();


        public MainWindowViewModel()
        {
            Line line = new Line();
            line.X1 = 0;
            line.Y1 = 0;
            line.X2 = 200;
            line.Y2 = 200;
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 10;

            Line line1 = new Line();
            line1.X1 = 100;
            line1.Y1 = 100;
            line1.X2 = 200;
            line1.Y2 = 200;
            line1.Stroke = Brushes.Red;
            line1.StrokeThickness = 10;

            Line line2 = new Line();
            line2.X1 = 600;
            line2.Y1 = 600;
            line2.Y1 = 200;
            line2.Y2 = 200;
            line2.Stroke = Brushes.Red;
            line2.StrokeThickness = 10;

            Lines.Add(line);
            Lines.Add(line1);
            Lines.Add(line2);

            Rectangle rect = new Rectangle()
            {
                Height = 50,
                Width = 50,
                Stroke = Brushes.Olive
            };
            Canvas.SetTop(rect, 50);
            Canvas.SetLeft(rect, 50);
            Rectangles.Add(rect);

            Ellipse ellipse = new Ellipse()
            {
                Height = 50,
                Width = 50,
                Stroke = Brushes.Olive,
                Fill =Brushes.Red
            };
            ellipse.MouseDown += Ellipse_MouseDown;
            Canvas.SetTop(ellipse, 100);
            Canvas.SetLeft(ellipse, 100);
            Circles.Add(ellipse);

            PointCollection points= new PointCollection();
            points.Add(new System.Windows.Point(10, 12));
            points.Add(new System.Windows.Point(20, 22));
            points.Add(new System.Windows.Point(30, 32));
            points.Add(new System.Windows.Point(40, 12));
            Polygon polygon = new Polygon()
            {
                Stroke = Brushes.Olive
            };
            polygon.Points = points;
            Polygons.Add(polygon);

            points.Add(new System.Windows.Point(50, 12));
            points.Add(new System.Windows.Point(60, 22));
            points.Add(new System.Windows.Point(70, 32));

            PointCollection points1 = new PointCollection();
            points1.Add(new System.Windows.Point(100, 212));
            points1.Add(new System.Windows.Point(200, 222));
            points1.Add(new System.Windows.Point(300, 232));
            points1.Add(new System.Windows.Point(400, 212));
            Polyline polyline = new Polyline()
            {
                Stroke = Brushes.Blue
            };
            polyline.Points = points1;
            Polylines.Add(polyline);

            Collection.Add(new CollectionContainer() { Collection = this.Lines });
            Collection.Add(new CollectionContainer() { Collection = this.Rectangles });
            Collection.Add(new CollectionContainer() { Collection = this.Circles });
            Collection.Add(new CollectionContainer() { Collection = this.Polygons });
            Collection.Add(new CollectionContainer() { Collection = this.Polylines });

            MouseDownCommand = new RelayCommand(new Action<object>(IncrementLineX), new Func<object, bool>(CanIncrementLineX));
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse =sender as Ellipse;
            ellipse.Width += 50;
        }

        public CompositeCollection Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                OnPropertyChanged("Collection");
            }
        }

        public ObservableCollection<Line> Lines
        {
            get
            {
                return lines;
            }

            set
            {
                lines = value;
                OnPropertyChanged("Lines");
            }
        }

        public ObservableCollection<Rectangle> Rectangles
        {
            get
            {
                return rectangles;
            }

            set
            {
                rectangles = value;
                OnPropertyChanged("Rectangles");
            }
        }

        public ObservableCollection<Ellipse> Circles
        {
            get
            {
                return circles;
            }

            set
            {
                circles = value;
                OnPropertyChanged("Circles");
            }
        }

        public ObservableCollection<Polygon> Polygons
        {
            get => polygons;
            set
            {
                polygons = value;
                OnPropertyChanged("Polygons");
            }
        }

        public ObservableCollection<Polyline> Polylines
        {
            get => polylines;
            set
            {
                polylines = value;
                OnPropertyChanged("Polylines");
            }
        }

        protected ICommand mouseDownCommand;
        public ICommand MouseDownCommand
        {
            get { return mouseDownCommand; }
            set
            {
                mouseDownCommand = value;
                OnPropertyChanged("MouseDownCommand");
            }
        }

        protected ICommand mouseDoubleDownCommand;
        public ICommand MouseDoubleDownCommand
        {
            get { return new LineCommand(); }
            set
            {
                mouseDownCommand = value;
                OnPropertyChanged("MouseDownCommand");
            }
        }

        public void IncrementLineX(object parameters)
        {
            Line selectedLine = Mouse.DirectlyOver as Line;
            selectedLine.X1 += 50;
        }
        public bool CanIncrementLineX(object parameters)
        {
            return true;
        }

    }
}
