   M S B A M L   `   `   `  ����X  Tnmct.ba.CashlessProject.Klant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:nmct.ba.CashlessProject.Klant.ViewModel'nmct.ba.CashlessProject.Klant.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Klant.View.Converters-nmct.ba.CashlessProject.Klant.View.Converters  5      0    *nmct.ba.CashlessProject.Klant.View.Account   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dvm5clr-namespace:nmct.ba.CashlessProject.Klant.ViewModel     5      Ic;clr-namespace:nmct.ba.CashlessProject.Klant.View.Converters     5        � DataContext  5
      7  1nmct.ba.CashlessProject.Klant.ViewModel.AccountVM  5   
    � 	Resources 5      J   Dnmct.ba.CashlessProject.Klant.View.Converters.StringToImageConverter   StringToImageConverter��%   &	          5   
   6#   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5       $��* �6   6)   �� 5!      $��* �6   6)   �� 5"      $��* �6   6)   �� 5#      $��* �6   6)   �� 5$      $��* �6   6)   �� 5%      $��* �6   6)   �� 5&      $��* �6   6)   �� 5'      $��* �6   6)   �� 5(      $��* �6   6)   �� 5)      $��* �6   6)   �� 5*      $��* �6   6)   �� 5+      $��* �6   6)   �� 5,      $��* �6   6)   �� 5-      $��* �6   6)   �� 5.      $��* �6   6)   .+�50   
   �� $��Naam:��6   $��16(�6!    �� TextAlignment$
 Left=�6/   $��2��6E   $��1��6R   �� 51   
   $��16(�6<   $
 Left=�6J   $��2��6`   $��2��6m   $��5��6}   $��0.4,0.2,99,0.4q�6�   ��6   �� *SelectedCustomer.Name+6�   �� 52   
   $��Adres:��6   $��16(�6"   $
 Left=�60   $��4��6F   $��1��6S   �� 53   
   $��16(�6>   $
 Left=�6L   $��4��6b   $��2��6o   $��5��6   $��0.4,0.2,99,0.4q�6�   ��6   �� *SelectedCustomer.Address+6�   �� 54   
   $��Saldo:��6   $��16(�6"   $
 Left=�60   $��6��6F   $��1��6S   �� 55   
   $��16(�6>   $
 Left=�6L   $��6��6b   $��2��6o   $��5��6   $��0.4,0.2,99,0.4q�6�   ��6   �� *SelectedCustomer.Balance+6�   �� 56   
   $��Foto:��6   $��16(�6!   $
 Left=�6/   $��8��6E   $��1��6R   �� 57   
   $��Geld Opladen��62   $��4��6J   $��10��6Z   $��3��6h   $��3��6|   $��98.8,0,0,26.2q�6�   ��6   �� *GeldOpladen+6�   �� 58   
   $��	Uitloggen��6/   $��4��6D   $��12��6T   $��3��6b   $��3��6v   $��98.8,26.2,0,0q�6�   ��6   �� *	Uitloggen+6�   �� 59   
   $��2��6�   $��2��6�   $��0.4,0.2,0.2,0q�6�   $��8��6�   $��9��6�   ��6   �� *SelectedCustomer.Picture+ �� 	Converter# [   �� UpdateSourceTrigger$ PropertyChanged=�6�   5;      5<      