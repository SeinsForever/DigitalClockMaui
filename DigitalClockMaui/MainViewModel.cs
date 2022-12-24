using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Timers;

namespace DigitalClockMaui;

internal partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        DigitList = new ObservableCollection<DigitItem>
        {
            new DigitItem() { Digit = 1 },
            new DigitItem() { Digit = 2 },
            new DigitItem() { IsDot = true},
            new DigitItem() { Digit = 3},
            new DigitItem() { Digit = 4},
            new DigitItem() { IsDot = true},
            new DigitItem() { Digit = 5},
            new DigitItem() { Digit = 6}
        };

        //DigitList[0].Digit = 10;
        //DigitList[1].Digit = 10;
        //DigitList[3].Digit = 10;
        //DigitList[4].Digit = 10;
        //DigitList[6].Digit = 10;
        //DigitList[7].Digit = 10;

        DigitList[0].Digit = 0;
        DigitList[1].Digit = 0;
        DigitList[3].Digit = 0;
        DigitList[4].Digit = 0;
        DigitList[6].Digit = 0;
        DigitList[7].Digit = 0;


        //System.Timers.Timer timer = new System.Timers.Timer(1000);

        //timer.Elapsed += new ElapsedEventHandler(NewTimeEvent);
        //timer.AutoReset = true;
        //timer.Start();
    }

    private async void NewTimeEvent(object sender, ElapsedEventArgs e)
    {
        DigitList[0].Digit = 10;
        DigitList[1].Digit = 10;
        DigitList[3].Digit = 10;
        DigitList[4].Digit = 10;
        DigitList[6].Digit = 10;
        DigitList[7].Digit = 10;

        DigitList[0].Digit = DateTime.Now.Hour / 10;
        DigitList[1].Digit = DateTime.Now.Hour % 10;
        DigitList[3].Digit = DateTime.Now.Minute / 10;
        DigitList[4].Digit = DateTime.Now.Minute % 10;
        DigitList[6].Digit = DateTime.Now.Second / 10;
        DigitList[7].Digit = DateTime.Now.Second % 10;

        DigitList[2].DotState = !DigitList[2].DotState;
        DigitList[5].DotState = !DigitList[5].DotState;
    }

    [ObservableProperty]
    ObservableCollection<DigitItem> digitList;

    [ObservableProperty]
    int counter = 0;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !IsBusy;

    [RelayCommand]
    void Click()
    {
        IsBusy = true;

        counter++;
        int helper = counter;
        for(int i = 7; i >= 0; i--)
        {
            if(i != 2 || i != 5)
            {
                DigitList[i].Digit = helper % 10;
                helper /= 10;
            }
        }    

        IsBusy = false;
    }

    public partial class DigitItem : ObservableObject
    {
        public DigitItem()
        {
            digit = 0;

        }

        [ObservableProperty]
        int digit;

        [ObservableProperty]
        bool isDot = false;

        [ObservableProperty]
        bool dotState = false;
    }
}