   M S B A M L   `   `   `  ����]  Ynmct.ba.cashlessproject.Medewerker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:nmct.ba.cashlessproject.Medewerker.View'nmct.ba.cashlessproject.Medewerker.View  5   	   k:clr-namespace:nmct.ba.cashlessproject.Medewerker.ViewModel,nmct.ba.cashlessproject.Medewerker.ViewModel  5   	   m;clr-namespace:nmct.ba.CashlessProject.Medewerker.Converters-nmct.ba.CashlessProject.Medewerker.Converters  5   	   3    -nmct.ba.cashlessproject.Medewerker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cv5clr-namespace:nmct.ba.cashlessproject.Medewerker.View     5   	   Ivm:clr-namespace:nmct.ba.cashlessproject.Medewerker.ViewModel     5   	   Ic;clr-namespace:nmct.ba.CashlessProject.Medewerker.Converters     5   	     � Title$  
MainWindow��5   	   $	��720��6   $
��1280��6)   $	��720��66   $
��1280��6F    � DataContext 5      @  :nmct.ba.cashlessproject.Medewerker.ViewModel.ApplicationVM  5	   
    � 	Resources 5      D   >nmct.ba.CashlessProject.Medewerker.Converters.BoolToVisibility   BoolToVisibility �� DataType<  6nmct.ba.cashlessproject.Medewerker.ViewModel.PageOneVM5   /nmct.ba.cashlessproject.Medewerker.View.PageOne?  9nmct.ba.cashlessproject.Medewerker.ViewModel.BestellingVM8   2nmct.ba.cashlessproject.Medewerker.View.BestellingA  ;nmct.ba.cashlessproject.Medewerker.ViewModel.InstellingenVM:   4nmct.ba.cashlessproject.Medewerker.View.Instellingen��%�   &	        (��      5      *, +)(�� E     5      *, +)(�� w     5      *, +)  5   
   6   �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      � $��688.8��6   $
��1270��6    � RowDefinitions 5   
   �� 5      $
��120* �6   �� 5      $��568.8* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   .+�5$   
   �� $��1��6   $
��Left=�6$   $��	71,45,0,0q�6?   $
��Wrap=�6R   $��Cashless Payment System��6f   $	��Top=�6�   $��4��6�   $��75��6�   $	��732��6�   $��48(�6�    �� TextAlignment$ Center=�6�   ���	#FFB0CF446�   � 5&   
   ���	#FFB0CF44$��6��6z   $��1��6�   y�6   �� *MenuVisibility+ �� 	Converter# [   5'      �� 5(      $��* �6    �� 5)      $��* �6    �� 5*      $��* �6    �� 5+      $��* �6    �� 5,      $��* �6    �� 5-      $��* �6     5/      �� 50      $��* �6#   �� 51      $��* �6#   �� 52      $��* �6#   �� 53      $��* �6#   �� 54      $��* �6#   �� 55      $��* �6#   �� 56      $��* �6#   �� 57      $��* �6#   �� 58      $��* �6#   �� 59      $��* �6#   �� 5:      $��* �6#   �� 5;      $��* �6#   �� 5<      $��* �6#   �� 5=      $��* �6#   .+�5@      �� $��10��69   $��2��6N   $��2��6[   $��0,0,0,0q�6l   ��6   �� *Pages+��5A      �� 5B      .R�5C      ��  �� Orientation$ 
Horizontal=�6%   $��0q�6>   5D      ��5F      �� 5G      .R�5H      �� $��20,0,0,0q�6!   $	��120��5I   "   
�������$��40��6A   $��10��6M   ��5H   4   �� *Name+��6M   �� *DataContext.ChangePageCommand+	 �� RelativeSource	 �� 
 �� AncestorType"
 ���6�   �� 5I   M   5J      5L      �� 5M      $��Kassa:��6   $��2��6'   $��12��6;   $
 Left=�6L   $��0.2,0,0.4,0q�6a   �� 5N      $��2��6D   $��12��6X   $
 Left=�6i   $��0.2,0,0.4,0q�6~   $��1��6�   ��6   �� *GekozenKassa.RegisterName+6�   �� 5O      $��	Uitloggen��60   $��12��6D   $
��Left=�6U   $��	0.2,0,0,0q�6p   $��3��6�   $	��Top=�6�   $	��181��6�   $��2��6�   $��20��6�   ��6   �� *LogOff+6�   �� 5P      $��2��60   $��12��6D   $
 Left=�6U   $��0.2,0,0.4,0q�6j   $��5��6   ��6   �� *Tijd+6   5Q      �� 5R   
   $��1��6   $��6��6F   ��6&   �� *CurrentPage+6F   5S      5T      