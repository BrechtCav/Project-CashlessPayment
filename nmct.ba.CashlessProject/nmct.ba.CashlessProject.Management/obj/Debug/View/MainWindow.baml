   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:nmct.ba.CashlessProject.Management.View'nmct.ba.CashlessProject.Management.View  5   	   k:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5   	   m;clr-namespace:nmct.ba.CashlessProject.Management.Converters-nmct.ba.CashlessProject.Management.Converters  5   	   3    -nmct.ba.CashlessProject.Management.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Cv5clr-namespace:nmct.ba.CashlessProject.Management.View     5   	   Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5   	   Ic;clr-namespace:nmct.ba.CashlessProject.Management.Converters     5   	     � Title$  
MainWindow��5   	   $	��720��6   $
��1280��6)   $	��720��66   $
��1280��6F    � DataContext 5      @  :nmct.ba.CashlessProject.Management.ViewModel.ApplicationVM  5	   
    � 	Resources 5      D   >nmct.ba.CashlessProject.Management.Converters.BoolToVisibility   BoolToVisibility �� DataType<  6nmct.ba.CashlessProject.Management.ViewModel.PageOneVM5   /nmct.ba.CashlessProject.Management.View.PageOne:  4nmct.ba.CashlessProject.Management.ViewModel.LoginVM3   -nmct.ba.CashlessProject.Management.View.Login?  9nmct.ba.CashlessProject.Management.ViewModel.MedewerkerVM8   2nmct.ba.CashlessProject.Management.View.Medewerker:	  4nmct.ba.CashlessProject.Management.ViewModel.KassaVM3
   -nmct.ba.CashlessProject.Management.View.Kassa:  4nmct.ba.CashlessProject.Management.ViewModel.KlantVM3   -nmct.ba.CashlessProject.Management.View.Klant?  9nmct.ba.CashlessProject.Management.ViewModel.StatistiekVM8   2nmct.ba.CashlessProject.Management.View.StatistiekA  ;nmct.ba.CashlessProject.Management.ViewModel.InstellingenVM:   4nmct.ba.CashlessProject.Management.View.Instellingen��%*  &	        (��      5      *, +)(�� E     5      *, +)(�� w     5      *, +)(�� �     5      *,	 +)(�� �     5      *, +)(��     5      *, +)(�� ?    5      *, +)  5   
   6   �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5         5!      5"      .��5#      � $��688.8��6   $
��1270��6    � RowDefinitions 5$   
   �� 5%      $
��120* �6   �� 5&      $��568.8* �6    � ColumnDefinitions 5(   
   �� 5)      $��* �6   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6   �� 5-      $��* �6   �� 5.      $��* �6   .+�50   
   �� $��1��6   $
��Left=�6$   $��	71,45,0,0q�6?   $
��Wrap=�6R   $��Cashless Payment System��6f   $	��Top=�6�   $��4��6�   $��75��6�   $	��732��6�   $��48(�6�    �� TextAlignment$ Center=�6�   ���	#FFB0CF446�   � 52   
   ���	#FFB0CF44$��6��6z   $��1��6�   y�6   �� *MenuVisibility+ �� 	Converter# [   53      �� 54      $��* �6    �� 55      $��* �6    �� 56      $��* �6    �� 57      $��* �6    �� 58      $��* �6    �� 59      $��* �6     5;      �� 5<      $��* �6#   �� 5=      $��* �6#   �� 5>      $��* �6#   �� 5?      $��* �6#   �� 5@      $��* �6#   �� 5A      $��* �6#   �� 5B      $��* �6#   �� 5C      $��* �6#   �� 5D      $��* �6#   �� 5E      $��* �6#   �� 5F      $��* �6#   �� 5G      $��* �6#   �� 5H      $��* �6#   �� 5I      $��* �6#   .+�5L      �� $��10��69   $��2��6N   $��2��6[   $��0,0,0,0q�6l   ��6   �� *Pages+��5M      �� 5N      .R�5O      ��  �� Orientation$ 
Horizontal=�6%   $��0q�6>   5P      ��5R      �� 5S      .R�5T      �� $��20,0,0,0q�6!   $	��120��5U   "   
�������$��40��6A   $��10��6M   ��5T   4   �� *Name+��6M   �� *DataContext.ChangePageCommand+	 �� RelativeSource	 �� 
 �� AncestorType"
 ���6�   �� 5U   M   5V      5X      �� 5Y      -   5         ��Name$ txbOrganisatie��5Y      $��Organisatie:��61   $��2��6E   $��12��6Y   $
 Left=�6j   $��0.2,0,0.4,0q�6   �� 5Z      -   5        $ txbOrganisatiegekozen��5Z      $��2��6U   $��12��6i   $
 Left=�6z   $��0.2,0,0.4,0q�6�   $��1��6�   ��68   �� *Organisatie+6�   �� 5[      $��	Uitloggen��60   $��12��6D   $
��Left=�6U   $��	0.2,0,0,0q�6p   $��3��6�   $	��Top=�6�   $	��181��6�   $��2��6�   $��20��6�   ��6   �� *LogOff+6�   �� 5\      $��2��60   $��12��6D   $
 Left=�6U   $��0.2,0,0.4,0q�6j   $��5��6   ��6   �� *Tijd+6   5]      �� 5^   
   $��1��6   $��6��6F   ��6&   �� *CurrentPage+6F   5_      5`      