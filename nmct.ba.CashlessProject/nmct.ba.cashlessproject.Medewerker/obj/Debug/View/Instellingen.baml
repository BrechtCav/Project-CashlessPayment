   M S B A M L   `   `   `  ����]  Ynmct.ba.cashlessproject.Medewerker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.cashlessproject.Medewerker.ViewModel,nmct.ba.cashlessproject.Medewerker.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Medewerker.Converters-nmct.ba.CashlessProject.Medewerker.Converters  5      :    4nmct.ba.cashlessproject.Medewerker.View.Instellingen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.cashlessproject.Medewerker.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Cp;clr-namespace:nmct.ba.CashlessProject.Medewerker.Converters  5        � DataContext  5      A  ;nmct.ba.cashlessproject.Medewerker.ViewModel.InstellingenVM  5   
    � 	Resources 5      H  Bnmct.ba.CashlessProject.Medewerker.Converters.PasswordBoxAssistant   PasswordBoxAssistant��%   &	          5   
   6!   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��244* �6   �� 5      $
��244* �6   �� 5      $
��244* �6   �� 5      $
��245* �6   �� 5      $	��244 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      $
��Auto �6   �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   G� -   5         G�Name$ PasswordBox��5+         BindPassword . $��2��5,   �   $��0.4,31.4,243.6,10.2q�6�   $��2��6�   $��2��6�   $��2��6�   $��14(�6     BoundPassword 63   ��  �� Path$ OldPassword� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6  G� 5-   
   -   5        $ NewPasswordBox��5-       . $��2��5.   �   $��0.4,29.8,243.6,11.8q�6�   $��4��6�   $��2��6�   $��2��6�   $��14(�6   63   �� $ NewPassword�$ TwoWay=�$	 PropertyChanged=�6  �� 50   
   $��Wijzig Wachtwoord��6   $��0.4,0.4,243.6,1.4q�6W   $��2��6r   $��8��6�   $��2��6�   ��6-   �� *ChangePasswordCommand+6�   �� 51   
   
���  ��$��2��6B   $��0.4,39,244.4,40.4q�6R   $��5��6m   $��4��6z   $��3��6�   ��6%   �� *Foutmelding+6�   �� 52   
   $
��Left=�6   $��49,40.4,0,0q�60   $��2��6E   $
��Wrap=�6R   $	��Top=�6f   $	��244��6~   $��2��6�   $��39��6�   $��14(�6�   $��2��6�   �� 6�   $�Huidig wachtwoord��6�   �� 6�   $�:��6�   6�   �� 53   
   $
��Left=�6   $��49,39.8,0,0q�60   $��4��6E   $
��Wrap=�6R   $	��Top=�6f   $	��244��6~   $��2��6�   $��39��6�   $��14(�6�   $��2��6�   �� 6�   $�Nieuw wachtwoord��6�   �� 6�   $�:��6�   6�   �� 54   
   $
��Left=�6   $��
49,0.2,0,0q�60   $��1��6D   $
��Wrap=�6Q   $	��Top=�6e   $	��244��6}   $��2��6�   $��39��6�   $��18(�6�   $��	Underline{�6�   $
��Bold"�6�   �� 6�   $�Wachtwoord wijzigen��6�   6  55      56      