   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.PagesWpfApp1.Pages  5          WpfApp1.Pages.OrdersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Pages     5        N� Title$  
OrdersPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   �� $��2��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� -   5         ��Name$ button��5      $'��!Распечатать отчёт��6%   $	��177��6A   $��16(�6M   $��Comic Sans MS)�6r   ���	#FF498C516�   �� 5      -   5        $��На главную��5   *   $��16(�6?   $��Comic Sans MS)�6M   ���	#FF498C516�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridHotels��5         AutoGenerateColumns .     
IsReadOnly . 
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ OrderID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 300 6R   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *	OrderID+6R     5      $ 
CustomerID��6%   $		 150 6X   
 69   �� *
CustomerID+6X     5      $ 
DateCreate��6%   $		 250 6X   
 69   �� *
DateCreate+6X     5       $ OrderStatus��6%   $		 100 6Z   
 6:   �� *OrderStatus+6Z     5!      $ ID��6%   $	 * 6H   
 61   �� *ID+6H   4  .System.Windows.Controls.DataGridTemplateColumn  5#      $	 * 6)      CellTemplate 5%      �� 5&      5(      5*      5,      � 5-   
   $��1��6    � ColumnDefinitions 5.      �� 5/      �� 50      .+�52      �� -   5        $#��Список клиентов��52      $��Center=�6/   $��Comic Sans MS)�6L   $��Center=�6g   $��16(�6�   $	��156��6�   ���	#FF498C51$��2��6�   57      �� 58   
   -   5         ��Name$ SPanelPages��58      $ 
Horizontal=�6+   $��4��6D   $��Center=�6Q   6p   5;      5<      