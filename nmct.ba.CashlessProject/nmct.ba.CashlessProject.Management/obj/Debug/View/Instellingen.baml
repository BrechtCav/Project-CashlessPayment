   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Management.Converters-nmct.ba.CashlessProject.Management.Converters  5      :    4nmct.ba.CashlessProject.Management.View.Instellingen   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Cp;clr-namespace:nmct.ba.CashlessProject.Management.Converters  5        � DataContext  5      A  ;nmct.ba.CashlessProject.Management.ViewModel.InstellingenVM  5   
    � 	Resources 5      H  Bnmct.ba.CashlessProject.Management.Converters.PasswordBoxAssistant   PasswordBoxAssistant��%   &	          5   
   6!   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��244* �6   �� 5      $
��244* �6   �� 5      $
��244* �6   �� 5      $
��245* �6   �� 5      $	��244 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      $
��Auto �6   �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   G� -   5         G�Name$ PasswordBox��5+         BindPassword . $��2��5,   �   $��0.4,0.6,243.6,40.2q�6�   $��9��6�   $��2��6�   $��2��6�   $��14(�6     BoundPassword 63   ��  �� Path$ OldPassword� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6  G� 5-   
   -   5        $ NewPasswordBox��5-       . $��2��5.   �   $��0.4,40.6,243.6,0.2q�6�   $��10��6�   $��2��6�   $��2��6�   $��14(�6   63   �� $ NewPassword�$ TwoWay=�$	 PropertyChanged=�6  �� 50   
   $��Wijzig Wachtwoord��6   $��0.4,1,243.6,0q�6W   $��2��6n   $��13��6~   $��2��6�   ��6-   �� *ChangePasswordCommand+6�   �� 51   
   
���  ��$��2��6B   $��0.4,9.8,244.4,28q�6R   $��12��6l   $��2��6z   $��3��6�   ��6%   �� *Foutmelding+6�   �� 52   
   $��1��6   $
��Left=�6%   $��0.4,9.6,0,0q�6@   $��9��6U   $
��Wrap=�6b   $	��Top=�6v   $	��244��6�   $��2��6�   $��39��6�   $��14(�6�   $��2��6�   �� 6�   $�Huidig wachtwoord��6�   �� 6�   $�:��6�   6	  �� 53   
   $��1��6   $
��Left=�6%   $��0.4,9.8,0,0q�6@   $��11��6U   $
��Wrap=�6c   $	��Top=�6w   $	��244��6�   $��2��6�   $��39��6�   $��14(�6�   $��2��6�   �� 6�   $�Nieuw wachtwoord��6�   �� 6�   $�:��6�   6	  �� 54   
   $��1��6   $
��Left=�6%   $��0.4,10.2,0,0q�6@   $��7��6V   $
��Wrap=�6c   $	��Top=�6w   $	��244��6�   $��2��6�   $��39��6�   $��18(�6�   $��2��6�   $��	Underline{�6�   $
��Bold"�6�   �� 6	  $�Wachtwoord wijzigen��6  6+  55      56      