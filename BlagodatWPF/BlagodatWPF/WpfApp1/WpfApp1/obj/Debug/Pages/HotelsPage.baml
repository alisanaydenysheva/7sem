   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.Pages.HotelsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5      -   5          N� Title$  
HotelsPage��5	       N� WindowHeight$ 1Q�6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGridHotels��5         AutoGenerateColumns .     
IsReadOnly . ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$	 Red��6#   � 5      $ 	#FF7100FF��6#   	 � Offset$	 0.903Q�65   � 5      $ 	#FFFFA400��6#   $
	 0.14Q�65   � 5      $ 	#FFFFEA00��6#   $	 0.297Q�65   � 5      $ 	#FF65FF00��6#   $
	 0.46Q�65   � 5      $ 	#FF00F9FF��6#   $
	 0.64Q�65   � 5      $ 	#FF0800FF��6#   $		 0.8Q�65   5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Hotel Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Name+6R     5      $ Stars��6%   $	 150 6N    64   �� *Stars+6N     5       $ Country��6%   $	 250 6W    66   �� *Country.Name+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $ * 6)      CellTemplate 5"      �� 5#      .R�5$      �� $��BtnEdit��6%   -   5        $
��Edit��5$   4   $
��10 5q�6C   $
��10 5q�6R   ��5%   "   �� 5&   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5'   *   � $	 Red��67   � 5(   *   $ 	#FF7100FF��67   $	 0.903Q�6I   � 5)   *   $ 	#FFFFA400��67   $
	 0.14Q�6I   � 5*   *   $ 	#FFFFEA00��67   $	 0.297Q�6I   � 5+   *   $ 	#FF65FF00��67   $
	 0.46Q�6I   � 5,   *   $ 	#FF00F9FF��67   $
	 0.64Q�6I   � 5-   *   $ 	#FF0800FF��67   $		 0.8Q�6I   5.   '   50      51      53      55      � 57   
   $��1��6    � ColumnDefinitions 58      �� 59      �� 5:      .+�5=      �� -   5        $��BtnAdd��5=      $��	Add Hotel��6#   $��0��67   $��30��6G   $	��300��6S   $
��10 0q�6_   $��16(�6�   $��Arial Black)�6�   ���	#FF060606��5>      �� 5?      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5@      � $	 Red��6'   � 5A      $ 	#FF7D00FF��6'   $	 1Q�69   � 5B      $ 
DarkOrange��6'   $
	 0.19Q�6:   � 5C      $ 	#FFFFD200��6'   $	 0.363Q�69   � 5D      $ 	#FF2BFF00��6'   $	 0.503Q�69   � 5E      $ 	#FF00FFF9��6'   $
	 0.65Q�69   � 5F      $ 	#FF0033FF��6'   $
	 0.81Q�69   5G      5I      �� 5J      -   5        $��BtnDel��5J      $��Delete��6#   $��1��64   $	��300��6E   $��30��6Q   $
��10 0q�6]   
���   �$��16(�6�   $��Segoe UI Black)�6�   ��5K      �� 5L      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5M      � $	 Red��6'   � 5N      $ 	#FF7D00FF��6'   $	 1Q�69   � 5O      $ 
DarkOrange��6'   $
	 0.19Q�6:   � 5P      $ 	#FFFFD200��6'   $	 0.363Q�69   � 5Q      $ 	#FF2BFF00��6'   $	 0.503Q�69   � 5R      $ 	#FF00FFF9��6'   $
	 0.65Q�69   � 5S      $ 	#FF0033FF��6'   $
	 0.81Q�69   5T      5V      5Y      5Z      5[      