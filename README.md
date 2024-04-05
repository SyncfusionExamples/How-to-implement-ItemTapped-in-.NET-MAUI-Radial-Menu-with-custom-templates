# How-to-implement-ItemTapped-in-.NET-MAUI-Radial-Menu-with-custom-templates
This section explains how to implement ItemTapped in .NET MAUI Radial Menu with custom templates.

**ViewModel**

**C#**

```
public class EmployeeModel : INotifyPropertyChanged 
{  
    public string Icon { get; set; }
    public string EmployeeName { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;
}

public class EmployeeViewModel 
{
    public ICommand RadialMenuCommand { get; private set; }
    private ObservableCollection<EmployeeModel> employeeCollection = new ObservableCollection<EmployeeModel>();
    public ObservableCollection<EmployeeModel> EmployeeCollection 
    {
        get { return employeeCollection; }
        set { employeeCollection = value; }
    }
        public EmployeeViewModel() {
        RadialMenuCommand = new Command(RadialItemTapped);

        EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE700", EmployeeName = "Alex" });
        EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE715", EmployeeName = "Lee" });
        EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE70A", EmployeeName = "Ben" });
        EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE716", EmployeeName = "Carl" });
        EmployeeCollection.Add(new EmployeeModel() { Icon = "\uE77E", EmployeeName = "Yang" });
    }

    void RadialItemTapped(object obj)
    {
        var alertResult = Application.Current.MainPage.DisplayAlert("Message", (obj as EmployeeModel)?.EmployeeName, null, "OK");
    }
}
```

**XAML**

```
 <radialMenu:SfRadialMenu x:Name="radial_Menu"
                          CenterButtonRadius="20"
                          CenterButtonBackFontFamily="MauiMaterialAssets"
                          CenterButtonFontFamily="MauiMaterialAssets"
                          CenterButtonFontSize="28"
                          CenterButtonText=""
                          ItemsSource="{Binding EmployeeCollection}">
     <radialMenu:SfRadialMenu.ItemTemplate>
         <DataTemplate>
             <StackLayout VerticalOptions="Center">
                 <Image>
                     <Image.GestureRecognizers>
                         <TapGestureRecognizer  Command="{Binding BindingContext.RadialMenuCommand,Source={x:Reference radial_Menu}, Mode=TwoWay}" CommandParameter="{Binding}" />
                     </Image.GestureRecognizers>
                     <Image.Source>
                         <FontImageSource FontFamily="MauiMaterialAssets" Color="Black" Glyph="{Binding Icon, Mode=TwoWay}" />
                     </Image.Source>
                 </Image>
             </StackLayout>
         </DataTemplate>
     </radialMenu:SfRadialMenu.ItemTemplate>
 </radialMenu:SfRadialMenu>

```