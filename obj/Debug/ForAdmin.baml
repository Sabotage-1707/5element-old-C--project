   M S B A M L   `   `   `  ����F  BLAB33_KPIAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LAB33_KPIAPLAB33_KPIAP  5   	       LAB33_KPIAP.ForAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LAB33_KPIAP     5   	     � Icon$   /Images/hnet.com-image.ico��5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Окно админа��5   	   $	��450��6   $	��800��6*   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ eGrid��5      $��0,0,0,70q�6#   5      �� 5   
   -   5         ��Name$ PokupButton��5   E   $��87,365,609,10q�6   $)��#Список Покупателей��6(   6p   �� 5   
   -   5        $ EmployeersButton��5   F   $��190,365,514,10q�6   $)��#Список Сотрудников��6)   6{   �� 5   
   -   5        $ ZakazButton��5   B   $��285,365,413,10q�6   $!��Список Заказов��6)   6m   �� 5   
   -   5        $ ZButton��5   <   $��386,365,312,10q�6   $��Отчет #1��6)   6e   �� 5   
   -   5        $��487,365,211,10q�5      $��Отчет #2��6)   6T   �� 5   
   -   5        $��619,365,95,10q�5      
������$��Обновить��6A   6l   �� 5   
   -   5        $ DeleteButton��5   S   $��704,365,10,10q�6   
�������$��Удалить��6A   6�   �� 5   
   -	   5        $��10,365,725,10q�5      
�������$��0q�6<   ��5      �� 5       �� ImageSource$ /Images/Back.png��6   6>   5      5      5      