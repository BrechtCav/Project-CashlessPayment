   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Management.Converters-nmct.ba.CashlessProject.Management.Converters  5      3    -nmct.ba.CashlessProject.Management.View.Klant   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Cp;clr-namespace:nmct.ba.CashlessProject.Management.Converters  5        � DataContext  5      :  4nmct.ba.CashlessProject.Management.ViewModel.KlantVM  5   
    � 	Resources 5      J   Dnmct.ba.CashlessProject.Management.Converters.StringToImageConverter   StringToImageConverterD   >nmct.ba.CashlessProject.Management.Converters.BoolToVisibility  BoolToVisibility��%:   &	        &	        5   
   6#     5   
   6   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      .+�5,   
   �� -   5         ��Name$ lblKlantenSelecteer��5,      $��Selecteer een klant��6-   $
��Left=�6K   $��1��6f   $��1��6v   $��Center=�6�   �� 5-   
   -   5         ��Name$ lstKlantenSelecteer��5-   [   $
��Left=�6x   $��371.2��6�   $��10��6�   $	��Top=�6�   $	��244��6�   $��1��6�   $��2��6�   ��6   �� *	ListKlant+ �� SelectedItem 64   �� *SelectedKlant+.  (System.Windows.Interactivity.Interaction   Triggers 5.      /  )System.Windows.Interactivity.EventTrigger  5/         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 50      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *	ToonKlant+51      53      �� 54   
   -   5         ��Name$ btnKlantenWijzig��54   T   $��Wijzig klant
��6n   $��3��6�   $��1��6�   $��Center=�6�   $	��155��6�   $��25��6�   $
��Left=�6�   ��6   �� *KlantWijzigen+{�63   �� *	BtnWijzig+6�   �� 55   
   -   5        $ lblKlantNaam��55      $
��Naam��6&   $��3��65   $
��Left=�6E   $��2��6`   $��Center=�6m   $
��23.9��6�   $��75.86��6�   $��0,7.03,0,6.99q�6�   �� 56   
   -   5         ��Name$ txtKlantNaam��56   D   $��3��6Z   $
��Left=�6j   $��23��6�   $��3��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,7.48,0,7.44q�6�   ��6   �� *Naam+{�6(   �� *Info+6�   �� 57   
   -   5        $ txtKlantAdres��57   E   $��3��6\   $
��Left=�6l   $��23��6�   $��5��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,7.48,0,7.44q�6�   ��6   �� *Adres+{�6)   �� *Info+6�   �� 58   
   -   5        $ txtKlantBalance��58   E   $��3��6^   $
��Left=�6n   $��23��6�   $��7��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��
0,7,0,7.92q�6�   ��6   �� *Saldo+{�6)   �� *Info+6�   �� 59   
   -   5        $ lblKlantAdres��59      $��Adres��6'   $��3��67   $
��Left=�6G   $��4��6b   $��Center=�6o   $��
0,6,0,5.96q�6�   �� 5:   
   -	   5        $ lblKantFoto��5:      $
��Foto��6%   $��4��64   $��Center=�6D   $��2��6a   $��Center=�6n   $��
0,0.96,0,0q�6�   �� 5;   
   $��Opslaan��6�   $��3��6�   $��11��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6�   $��3.2,4.92,85.8,8q�6  ��6   �� *KlantOpslaan+y�63   �� *
BtnOpslaan+ �� 	Converter# [ 6  �� 5<   
   $��	Annuleren��6�   $��4��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6�   $��11��6�   $��105.007,4.92,227.993,8q�6  $��2��6'  ��6   �� *KlantAnnuleren+y�64   �� *BtnAnnuleren+# [ 6'  �� 5=   
   -
   5        $ lblKlantBalance��5=      $��Saldo��6)   $��3��69   $
��Left=�6I   $��6��6d   $��Center=�6q   $��
0,5.96,0,6q�6�   �� 5>   
   $��2��6�   $��4��6�   $��145.4,0.2,145.4,0.4q�6�   $��3��6�   $��5��6�   ��6   �� *Image+# [   �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5?   
   $��3��6   $
��Left=�6$   $��0.4,10.2,0,0q�6?   $��9��6U   $
��Wrap=�6b   $	��Top=�6�   $��2��6�   $��37��6�   $	��488��6�   $��2��6�   
���  ����6v   �� *Foutmelding+6�   5A      5B      