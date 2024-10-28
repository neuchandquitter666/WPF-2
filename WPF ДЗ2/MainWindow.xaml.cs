using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WPF_ДЗ2
{
    /*    //Задание 1
        public partial class MainWindow : Window
        {
            private string[] resumeParts = {
                   "Имя: Иван Иванов",
                   "Профессия: Бездельник",
                   "Опыт работы: нет",
                   "Навыки:  биение баклуш, точение ляс, круглосутоный сон,служба в диванных войсках ",
                   "Контакты: ivanov.bezdelnic@email.com, +7 (999) 666-13-00"
               };
            public MainWindow()
            {
                InitializeComponent();

                int totalChars = 0;
                foreach (string part in resumeParts)
                {
                    totalChars += part.Length;
                    MessageBox.Show(part);
                }

                double averageChars = (double)totalChars / resumeParts.Length;
                MessageBox.Show($"Среднее количество символов: {averageChars:F2}", "Статистика");
            }
        }

    */






    //Задание 2
    /*    public partial class MainWindow : Window
        {
            private int secretNumber;
            private int attempts;

            public MainWindow()
            {
                InitializeComponent();
            }

            private void StartGame_Click(object sender, RoutedEventArgs e)
            {
                StartNewGame();
            }

            private void StartNewGame()
            {
                secretNumber = new Random().Next(1, 2001); // Загадать число от 1 до 2000
                attempts = 0; // Обнулить количество попыток
                GuessNumber();
            }

            private void GuessNumber()
            {
                attempts++;
                string message = $"Попробуйте угадать число! Попытка {attempts}:";
                string input = Microsoft.VisualBasic.Interaction.InputBox(message, "Угадай число", "", -1, -1);

                if (int.TryParse(input, out int guessedNumber))
                {
                    if (guessedNumber < 1 || guessedNumber > 2000)
                    {
                        MessageBox.Show("Введите число от 1 до 2000.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        GuessNumber(); // Запросить снова
                    }
                    else if (guessedNumber < secretNumber)
                    {
                        MessageBox.Show("Слишком маленькое число!", "Попробуйте снова", MessageBoxButton.OK, MessageBoxImage.Information);
                        GuessNumber(); // Запросить снова
                    }
                    else if (guessedNumber > secretNumber)
                    {
                        MessageBox.Show("Слишком большое число!", "Попробуйте снова", MessageBoxButton.OK, MessageBoxImage.Information);
                        GuessNumber(); // Запросить снова
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show($"Поздравляем! Вы угадали число {secretNumber} за {attempts} попыток.\nХотите сыграть еще раз?",
                                                                   "Угадал!",
                                                                   MessageBoxButton.YesNo,
                                                                   MessageBoxImage.Information);
                        if (result == MessageBoxResult.Yes)
                        {
                            StartNewGame(); // Начать новую игру
                        }
                        else
                        {
                            Application.Current.Shutdown(); // Закрыть приложение
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный ввод! Пожалуйста, введите число.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    GuessNumber(); // Запросить снова
                }
            }
        }
    */





    //Задание 3
    /*  public partial class MainWindow : Window
      {
          private Ellipse staticElement;
          private double distanceThreshold = 20; // Расстояние, на котором статик убегает

          public MainWindow()
          {
              InitializeComponent();

              // Создаем статический элемент (круг)
              staticElement = new Ellipse();
              staticElement.Fill = Brushes.Red;
              staticElement.Width = 50;
              staticElement.Height = 50;

              // Устанавливаем начальное положение статика
              Canvas.SetLeft(staticElement, 100);
              Canvas.SetTop(staticElement, 100);

              // Добавляем статик на канвас
              mainCanvas.Children.Add(staticElement);

              // Обработчик события движения мыши
              mainCanvas.MouseMove += MainCanvas_MouseMove;
          }

          private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
          {
              // Получаем координаты курсора
              Point mousePosition = e.GetPosition(mainCanvas);

              // Проверяем расстояние между курсором и статиком
              double distance = Math.Sqrt(Math.Pow(Canvas.GetLeft(staticElement) - mousePosition.X, 2) +
                                        Math.Pow(Canvas.GetTop(staticElement) - mousePosition.Y, 2));

              // Если курсор близко к статику, то убегаем
              if (distance < distanceThreshold)
              {
                  // Вычисляем новое положение статика
                  double newX = Math.Max(0, Math.Min(mainCanvas.ActualWidth - staticElement.Width, mousePosition.X + 50));
                  double newY = Math.Max(0, Math.Min(mainCanvas.ActualHeight - staticElement.Height, mousePosition.Y + 50));

                  // Перемещаем статик
                  Canvas.SetLeft(staticElement, newX);
                  Canvas.SetTop(staticElement, newY);
              }
          }
      }*/







    /*    //Задание 4
        public partial class MainWindow : Window
        {
            private Point startPoint;
            private bool isDrawing = false;
            private int staticCount = 0;
            private List<Rectangle> staticShapes = new List<Rectangle>();

            public MainWindow()
            {
                InitializeComponent();
            }

            private void Window_MouseDown(object sender, MouseButtonEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    startPoint = e.GetPosition(MainCanvas);
                    isDrawing = true;
                }

                if (e.RightButton == MouseButtonState.Pressed)
                {
                    Point clickPoint = e.GetPosition(MainCanvas);
                    HandleRightClick(clickPoint);
                }
            }

            private void Window_MouseMove(object sender, MouseEventArgs e)
            {
                if (isDrawing)
                {
                    Point currentPoint = e.GetPosition(MainCanvas);
                    DrawRectangle(startPoint, currentPoint);
                }
            }

            private void Window_MouseUp(object sender, MouseButtonEventArgs e)
            {
                if (isDrawing)
                {
                    Point endPoint = e.GetPosition(MainCanvas);
                    CreateStaticShape(startPoint, endPoint);
                    isDrawing = false;
                }
            }

            private void DrawRectangle(Point start, Point end)
            {
                MainCanvas.Children.Clear(); // Удаляем предварительный прямоугольник перед рисованием нового
                var rect = new Rectangle
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = Brushes.Transparent
                };

                double x = Math.Min(start.X, end.X);
                double y = Math.Min(start.Y, end.Y);
                double width = Math.Max(10, Math.Abs(start.X - end.X));
                double height = Math.Max(10, Math.Abs(start.Y - end.Y));

                rect.Width = width;
                rect.Height = height;
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);

                MainCanvas.Children.Add(rect);
            }

            private void CreateStaticShape(Point start, Point end)
            {
                double x = Math.Min(start.X, end.X);
                double y = Math.Min(start.Y, end.Y);
                double width = Math.Max(10, Math.Abs(start.X - end.X));
                double height = Math.Max(10, Math.Abs(start.Y - end.Y));

                if (width < 10 || height < 10)
                {
                    MessageBox.Show("Минимальный размер статиков 10x10.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                staticCount++;
                var rect = new Rectangle
                {
                    Fill = new SolidColorBrush(Color.FromRgb((byte)(staticCount * 30 % 256), (byte)(staticCount * 50 % 256), (byte)(staticCount * 70 % 256))),
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Tag = staticCount //  Tag для хранения порядкового номера
                };

                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                rect.Width = width;
                rect.Height = height;
                rect.MouseRightButtonDown += Rectangle_MouseRightButtonDown;
                rect.MouseDoubleClick += Rectangle_MouseDoubleClick;

                MainCanvas.Children.Add(rect);
                staticShapes.Add(rect);
            }

            private void Rectangle_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
            {
                var rectangle = sender as Rectangle;
                if (rectangle != null)
                {
                    double area = rectangle.Width * rectangle.Height;
                    MessageBox.Show($"Площадь: {area} \nКоординаты: ({Canvas.GetLeft(rectangle)}, {Canvas.GetTop(rectangle)})",
                                    "Информация о статике",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }

            private void Rectangle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                var rectangle = sender as Rectangle;
                if (rectangle != null)
                {
                    MainCanvas.Children.Remove(rectangle);
                    staticShapes.Remove(rectangle);
                }
            }

            private void HandleRightClick(Point clickPoint)
            {
                Rectangle clickedRectangle = null;
                int highestTag = 0;

                foreach (Rectangle rect in staticShapes)
                {
                    double left = Canvas.GetLeft(rect);
                    double top = Canvas.GetTop(rect);
                    double right = left + rect.Width;
                    double bottom = top + rect.Height;

                    if (clickPoint.X >= left && clickPoint.X <= right && clickPoint.Y >= top && clickPoint.Y <= bottom)
                    {
                        int currentTag = (int)rect.Tag;
                        if (currentTag > highestTag)
                        {
                            highestTag = currentTag;
                            clickedRectangle = rect;
                        }
                    }
                }

                if (clickedRectangle != null)
                {
                    double area = clickedRectangle.Width * clickedRectangle.Height;
                    MessageBox.Show($"Площадь: {area} \nКоординаты: ({Canvas.GetLeft(clickedRectangle)}, {Canvas.GetTop(clickedRectangle)})",
                                    "Информация о статике",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
        }*/






    //Задание 5
    /*
        public partial class MainWindow : Window
        {
            private Ellipse staticElement;
            private double distanceThreshold = 20; // Расстояние, на котором статик убегает

            public MainWindow()
            {
                InitializeComponent();

                // Создаем статический элемент (круг)
                staticElement = new Ellipse();
                staticElement.Fill = Brushes.Red;
                staticElement.Width = 50;
                staticElement.Height = 50;

                // Устанавливаем начальное положение статика
                Canvas.SetLeft(staticElement, 100);
                Canvas.SetTop(staticElement, 100);

                // Добавляем статик на канвас
                mainCanvas.Children.Add(staticElement);

                // Обработчик события движения мыши
                mainCanvas.MouseMove += MainCanvas_MouseMove;
            }

            private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                // Получаем координаты курсора
                Point mousePosition = e.GetPosition(mainCanvas);

                // Проверяем расстояние между курсором и статиком
                double distance = Math.Sqrt(Math.Pow(Canvas.GetLeft(staticElement) - mousePosition.X, 2) +
                                          Math.Pow(Canvas.GetTop(staticElement) - mousePosition.Y, 2));

                // Если курсор близко к статику, то убегаем
                if (distance < distanceThreshold)
                {
                    // Вычисляем новое положение статика
                    double newX = Math.Max(0, Math.Min(mainCanvas.ActualWidth - staticElement.Width, mousePosition.X + 50));
                    double newY = Math.Max(0, Math.Min(mainCanvas.ActualHeight - staticElement.Height, mousePosition.Y + 50));

                    // Перемещаем статик
                    Canvas.SetLeft(staticElement, newX);
                    Canvas.SetTop(staticElement, newY);
                }
            }
        }*/






    //Задание 6
    /*    public partial class MainWindow : Window
        {
            private Ellipse staticElement;
            private double distanceThreshold = 20; // Расстояние, на котором статик убегает

            public MainWindow()
            {
                InitializeComponent();

                // Создаем статический элемент (круг)
                staticElement = new Ellipse();
                staticElement.Fill = Brushes.Red;
                staticElement.Width = 50;
                staticElement.Height = 50;

                // Устанавливаем начальное положение статика
                Canvas.SetLeft(staticElement, 100);
                Canvas.SetTop(staticElement, 100);

                // Добавляем статик на канвас
                mainCanvas.Children.Add(staticElement);

                // Обработчик события движения мыши
                mainCanvas.MouseMove += MainCanvas_MouseMove;
            }

            private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                // Получаем координаты курсора
                Point mousePosition = e.GetPosition(mainCanvas);

                // Проверяем расстояние между курсором и статиком
                double distance = Math.Sqrt(Math.Pow(Canvas.GetLeft(staticElement) - mousePosition.X, 2) +
                                          Math.Pow(Canvas.GetTop(staticElement) - mousePosition.Y, 2));

                // Если курсор близко к статику, то убегаем
                if (distance < distanceThreshold)
                {
                    // Вычисляем новое положение статика
                    double newX = Math.Max(0, Math.Min(mainCanvas.ActualWidth - staticElement.Width, mousePosition.X + 50));
                    double newY = Math.Max(0, Math.Min(mainCanvas.ActualHeight - staticElement.Height, mousePosition.Y + 50));

                    // Перемещаем статик
                    Canvas.SetLeft(staticElement, newX);
                    Canvas.SetTop(staticElement, newY);
                }
            }
        }*/







    //Встреча 2 Задание 1
    /*    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                // данные из элементов управления
                string lastName = LastNameTextBox.Text;
                string firstName = FirstNameTextBox.Text;
                string middleName = MiddleNameTextBox.Text;
                string gender = GenderComboBox.SelectedItem.ToString();
                DateTime birthDate = BirthDatePicker.SelectedDate.Value;
                string maritalStatus = MaritalStatusComboBox.SelectedItem.ToString();
                string additionalInfo = AdditionalInfoTextBox.Text;

                // строки с данными
                string data = $"Фамилия: {lastName}\n" +
                             $"Имя: {firstName}\n" +
                             $"Отчество: {middleName}\n" +
                             $"Пол: {gender}\n" +
                             $"Дата рождения: {birthDate.ToShortDateString()}\n" +
                             $"Семейный статус: {maritalStatus}\n" +
                             $"Дополнительная информация: {additionalInfo}";

                // Сохраняем данные в файл
                try
                {
                    string filePath = "personal_data.txt";
                    File.WriteAllText(filePath, data);
                    MessageBox.Show("Данные успешно сохранены в файл: " + filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
                }
            }
        }*/







    //Встреча 2 Задание 1 
    /*    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();

                // Создаем круглую форму
                Ellipse circle = new Ellipse
                {
                    Width = 300,
                    Height = 300,
                    Fill = Brushes.LightBlue
                };

                // Добавляем круг на форму
                MainGrid.Children.Add(circle);

                // Добавляем элементы DateTimePicker
                DateTimePicker datePicker1 = new DateTimePicker();
                datePicker1.HorizontalAlignment = HorizontalAlignment.Center;
                datePicker1.VerticalAlignment = VerticalAlignment.Center;
                MainGrid.Children.Add(datePicker1);

                DateTimePicker datePicker2 = new DateTimePicker();
                datePicker2.HorizontalAlignment = HorizontalAlignment.Center;
                datePicker2.VerticalAlignment = VerticalAlignment.Center;
                datePicker2.Margin = new Thickness(0, 100, 0, 0); // Смещаем второй DateTimePicker вниз
                MainGrid.Children.Add(datePicker2);

                // Добавляем элемент Label для вывода результата
                Label resultLabel = new Label
                {
                    Content = "Разница в днях:",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 200, 0, 0) // Смещаем Label вниз
                };
                MainGrid.Children.Add(resultLabel);

                // Обработчик события изменения даты
                datePicker1.SelectedDateChanged += (sender, e) => CalculateDaysDifference(datePicker1, datePicker2, resultLabel);
                datePicker2.SelectedDateChanged += (sender, e) => CalculateDaysDifference(datePicker1, datePicker2, resultLabel);
            }

            private void CalculateDaysDifference(DateTimePicker datePicker1, DateTimePicker datePicker2, Label resultLabel)
            {
                if (datePicker1.SelectedDate != null & amp; &amp; datePicker2.SelectedDate != null)
                {
                    TimeSpan difference = datePicker2.SelectedDate.Value - datePicker1.SelectedDate.Value;
                    resultLabel.Content = $"Разница в днях: {difference.Days}";
                }
            }
        }
    */

    //Встреча 2 Задание 3
    /*    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                // Получаем дату рождения из TextBox
                if (DateTime.TryParse(txtBirthday.Text, out DateTime birthdayDate))
                {
                    // Устанавливаем выбранную дату в MonthCalendar
                    monthCalendar.SelectedDate = birthdayDate;
                }
                else
                {
                    // Выводим сообщение об ошибке, если ввод некорректен
                    MessageBox.Show("Некорректный формат даты. Введите дату в формате ДД.ММ.ГГГГ.");
                }
            }
        }*/





    /*    Встреча 3 Задание 1
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }

            private async void SelectFile_Click(object sender, RoutedEventArgs e)
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    await ReadFileAsync(openFileDialog.FileName);
                }
            }

            private async Task ReadFileAsync(string filePath)
            {
                var fileInfo = new FileInfo(filePath);
                long totalBytes = fileInfo.Length;
                long bytesRead = 0;

                // Обнуляем ProgressBar и текст
                ProgressBar.Value = 0;
                StatusText.Text = "Чтение файла...";

                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                {
                    char[] buffer = new char[1024];
                    int readLength;

                    while ((readLength = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        bytesRead += readLength;

                        // Обновляем прогресс
                        ProgressBar.Value = (double)bytesRead / totalBytes * 100;

                        // Обновляем текст состояния
                        StatusText.Text = $"Прочитано {bytesRead} байт из {totalBytes}";

                        // Ждем перед следующим чтением (опционально, для имитации долгого чтения)
                        await Task.Delay(50);
                    }
                }

                StatusText.Text = "Чтение завершено!";
            }
        }
    */



    //Встреча 3 Задание 2
    /*        public partial class MainWindow : Window
            {
                public List<User> Users { get; set; } = new List<User>();

                public MainWindow()
                {
                    InitializeComponent();
                }

                private void AddButton_Click(object sender, RoutedEventArgs e)
                {
                    var user = new User
                    {
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        Email = EmailTextBox.Text,
                        Phone = PhoneTextBox.Text
                    };
                    Users.Add(user);
                    UpdateUserList();
                    ClearFields();
                }

                private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    if (UsersListBox.SelectedItem is User selectedUser)
                    {
                        FirstNameTextBox.Text = selectedUser.FirstName;
                        LastNameTextBox.Text = selectedUser.LastName;
                        EmailTextBox.Text = selectedUser.Email;
                        PhoneTextBox.Text = selectedUser.Phone;
                    }
                }

                private void DeleteButton_Click(object sender, RoutedEventArgs e)
                {
                    if (UsersListBox.SelectedItem is User selectedUser)
                    {
                        Users.Remove(selectedUser);
                        UpdateUserList();
                        ClearFields();
                    }
                }

                private void UpdateUserList()
                {
                    UsersListBox.ItemsSource = null;
                    UsersListBox.ItemsSource = Users;
                }

                private void ClearFields()
                {
                    FirstNameTextBox.Clear();
                    LastNameTextBox.Clear();
                    EmailTextBox.Clear();
                    PhoneTextBox.Clear();
                    UsersListBox.SelectedItem = null;
                }

                private void ExportToTxt_Click(object sender, RoutedEventArgs e)
                {
                    using (var writer = new StreamWriter("users.txt"))
                    {
                        foreach (var user in Users)
                        {
                            writer.WriteLine($"{user.FirstName},{user.LastName},{user.Email},{user.Phone}");
                        }
                    }
                    MessageBox.Show("Данные экспортированы в users.txt");
                }

                private void ImportFromTxt_Click(object sender, RoutedEventArgs e)
                {
                    if (File.Exists("users.txt"))
                    {
                        Users.Clear();
                        using (var reader = new StreamReader("users.txt"))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                var parts = line.Split(',');
                                if (parts.Length == 4)
                                {
                                    var user = new User
                                    {
                                        FirstName = parts[0],
                                        LastName = parts[1],
                                        Email = parts[2],
                                        Phone = parts[3]
                                    };
                                    Users.Add(user);
                                }
                            }
                        }
                        UpdateUserList();
                        MessageBox.Show("Данные импортированы из users.txt");
                    }
                    else
                    {
                        MessageBox.Show("Файл users.txt не найден.");
                    }
                }

                private void ExportToXml_Click(object sender, RoutedEventArgs e)
                {
                    var serializer = new XmlSerializer(typeof(List<User>));
                    using (var stream = new FileStream("users.xml", FileMode.Create))
                    {
                        serializer.Serialize(stream, Users);
                    }
                    MessageBox.Show("Данные экспортированы в users.xml");
                }

                private void ImportFromXml_Click(object sender, RoutedEventArgs e)
                {
                    if (File.Exists("users.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(List<User>));
                        using (var stream = new FileStream("users.xml", FileMode.Open))
                        {
                            Users = (List<User>)serializer.Deserialize(stream);
                        }
                        UpdateUserList();
                        MessageBox.Show("Данные импортированы из users.xml");
                    }
                    else
                    {
                        MessageBox.Show("Файл users.xml не найден.");
                    }
                }
            }

            [Serializable]
            public class User
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string Phone { get; set; }

                public override string ToString()
                {
                    return $"{FirstName} {LastName} - {Email} - {Phone}";
                }
            }
        }*/



    //Задание 8
    /*public partial class MainWindow : Window
    {
        private double _totalRevenue = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FuelTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                FuelPriceTextBox.Text = selectedItem.Tag.ToString();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (LitersRadioButton.IsChecked == true)
            {
                LitersTextBox.IsEnabled = true;
                AmountTextBox.IsEnabled = false;
            }
            else if (AmountRadioButton.IsChecked == true)
            {
                LitersTextBox.IsEnabled = false;
                AmountTextBox.IsEnabled = true;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double total = 0;
            double fuelPrice = double.Parse(FuelPriceTextBox.Text);
            double liters = 0;

            if (LitersRadioButton.IsChecked == true)
            {
                liters = double.Parse(LitersTextBox.Text);
                total += liters * fuelPrice;
            }
            else if (AmountRadioButton.IsChecked == true)
            {
                double amount = double.Parse(AmountTextBox.Text);
                liters = amount / fuelPrice;
                total += amount;
            }

            // Мини-кафе
            total += GetCafeTotal();

            TotalAmountTextBox.Text = total.ToString();
            _totalRevenue += total;
            TotalRevenueTextBlock.Text = $"Общая выручка: {_totalRevenue} rub";

            MessageBoxResult result = MessageBox.Show("Вы хотите очистить форму?", "Оповещение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                ClearFields();

            // Запрос на очистку через 10 секунд
            var timer = new System.Timers.Timer(10000);
            timer.Elapsed += (s, ev) =>
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Форма очищена автоматически.");
                    ClearFields();
                });
                timer.Stop();
            };
            timer.Start();
        }

        private double GetCafeTotal()
        {
            double total = 0;
            if (CoffeeCheckBox.IsChecked == true)
                total += double.Parse(CoffeeCheckBox.Tag.ToString());
            if (CroissantCheckBox.IsChecked == true)
                total += double.Parse(CroissantCheckBox.Tag.ToString());
            if (SodaCheckBox.IsChecked == true)
                total += double.Parse(SodaCheckBox.Tag.ToString());
            if (SandwichCheckBox.IsChecked == true)
                total += double.Parse(SandwichCheckBox.Tag.ToString());
            return total;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            LitersTextBox.Clear();
            AmountTextBox.Clear();
            TotalAmountTextBox.Clear();
            FuelTypeComboBox.SelectedIndex = 0;
            CoffeeCheckBox.IsChecked = false;
            CroissantCheckBox.IsChecked = false;
            SodaCheckBox.IsChecked = false;
            SandwichCheckBox.IsChecked = false;
            _totalRevenue = 0;
            TotalRevenueTextBlock.Text = "Общая выручка: 0 rub";
        }
    }*/

    //Задание 7
   /* public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(TargetDateEdit.Text, out DateTime targetDate))
            {
                TimeSpan timeRemaining = targetDate - DateTime.Now;

                if (YearsRadioButton.IsChecked == true)
                {
                    ResultLabel.Content = $"Осталось {timeRemaining.TotalDays / 365.25:F2} лет";
                }
                else if (MonthsRadioButton.IsChecked == true)
                {
                    ResultLabel.Content = $"Осталось {timeRemaining.TotalDays / 30.44:F2} месяцев";
                }
                else if (DaysRadioButton.IsChecked == true)
                {
                    ResultLabel.Content = $"Осталось {timeRemaining.Days} дней";
                }
                else if (HoursRadioButton.IsChecked == true)
                {
                    ResultLabel.Content = $"Осталось {timeRemaining.Hours} часов";
                }
                else if (MinutesRadioButton.IsChecked == true)
                {
                    ResultLabel.Content = $"Осталось {timeRemaining.Minutes} минут";
                }
                else if (SecondsRadioButton.IsChecked == true)
                {
                    ResultLabel.Content = $"Осталось {timeRemaining.Seconds} секунд";
                }
            }
            else
            {
                ResultLabel.Content = "Неверный формат даты";
            }
        }
    }*/
}
            
        
   

