   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5      8    2nmct.ba.CashlessProject.Management.View.Statistiek   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        � DataContext  5
      ?  9nmct.ba.CashlessProject.Management.ViewModel.StatistiekVM  5   
   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      .+�5'   
   �� -   5         ��Name$ lstStatistieken��5'   8   $
��Left=�6Q   $	��357��6l   $��11��6y   $	��Top=�6�   $
��1178��6�   $��1��6�   $��3��6�   $��5��6�   $��0.4,23.2,0,0q�6�   ��6   �� *EindResultaat+6�   �� 5(   
   -   5         ��Name$ cboStatistiekenKassa��5(   \   $��3��6z   $
��Left=�6�   $��133.2,6,0,0q�6�   $��1��6�   $	��Top=�6�   $��246.4��6�   $��2��6�   $��26.44��6  ��6   �� *	KassaList+ �� SelectedItem 65   �� *SelectedKassa+��5)      �� 5*       �� 
TargetType" ��6   .�5+      ��  �� Property � �� �� Value$ 20��6/   5,      5.      �� 5/   
   -   5        $ cboStatistiekenProduct��5/   `   $��4��6�   $
��Left=�6�   $��202.4,6,0,0q�6�   $��1��6�   $	��Top=�6�   $	��244��6�   $��2��6�   ��6   �� *ProductList+ 67   �� *SelectedProduct+��50      �� 51      " ��6   .�52      ��  � ��$ 20��6/   53      55      (  "System.Windows.Controls.DatePicker  56   
   -   5        	  Name$	 dtpStatistiekenVan��56   7   $��1��6S   $
��Left=�6c   $
��26.4��6~   $��0,6,0,0q�6�   $��1��6�   $	��Top=�6�   $	��244��6�   
   FirstDayOfWeek$
 Monday=�6�      SelectedDate 6   �� *
FromDate+6�   �� 57   
   -   5         ��Name$ lblStatistiekenVan��57      $	��Van��6,   $��1��6:   $
��Left=�6J   $��0.8,5.96,0,0q�6e   $	��Top=�6{     58   
   -   5        $	 dtpStatistiekenTot��58   8   $��2��6T   $
��Left=�6d   $
��26.4��6   $��
60.8,6,0,0q�6�   $��1��6�   $	��Top=�6�   $	��244��6�   $��2��6�   $
 Monday=�6�    6   �� *	UntilDate+6�   �� 59   
   -   5        $ lblStatistiekenTot��59      $	��Tot��6,   $��2��6:   $
��Left=�6J   $��60.8,5.96,0,0q�6e   $	��Top=�6|   �� 5:   
   -   5        $ lblStatistiekenKassa��5:      $��Kassa��6.   $��3��6>   $
��Left=�6N   $��133.2,5.96,0,0q�6i   $	��Top=�6�   �� 5;   
   -	   5        $ lblStatistiekenProduct��5;      $��Product��60   $��4��6B   $
��Left=�6R   $��202.4,5.96,0,0q�6m   $	��Top=�6�   $��2��6�   $
��68.8��6�   �� 5<   
   -
   5         ��Name$ btnStatistiekenZoek��5<   *   $
��Zoek��6G   $��1��6V   $
��Left=�6f   $��26.44��6�   $��	0.8,5,0,0q�6�   $��2��6�   $	��Top=�6�   $	��244��6�   $��2��6�   ��6   �� *Zoek+6�   �� 5=   
   $��2��6   $
��Left=�6$   $��22.4,6.8,0,0q�6?   $��2��6U   $
��Wrap=�6b   $	��Top=�6�   $��4��6�   $	��912��6�   $��16(�6�   ��6v   �� *
PerProduct+6�   5>      5?      