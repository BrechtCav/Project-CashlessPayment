   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Management.Converters-nmct.ba.CashlessProject.Management.Converters  5      3    -nmct.ba.CashlessProject.Management.View.Kassa   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Cp;clr-namespace:nmct.ba.CashlessProject.Management.Converters  5        � DataContext  5      :  4nmct.ba.CashlessProject.Management.ViewModel.KassaVM  5   
    � 	Resources 5      D   >nmct.ba.CashlessProject.Management.Converters.BoolToVisibility   BoolToVisibility��%   &	          5   
   6   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   �� -   5         ��Name$ lblKassaSelecteer��5+      $��Selecteer een kassa��6+   $
��Left=�6I   $��1��6d   $��1��6t   $��Center=�6�   �� 5,   
   -   5         ��Name$ lstKassaSelecteer��5,   {   $
��Left=�6�   $��417.12��6�   $��11��6�   $	��Top=�6�   $	��244��6�   $��1��6�   $��2��6   �� SelectedItem 6   �� *GekozenKassa+{�68   �� *
KassaLijst+��6Y   �� *	ListKassa+.  (System.Windows.Interactivity.Interaction   Triggers 5-      /  )System.Windows.Interactivity.EventTrigger  5.         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5/      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *	ToonKassa+50      52      �� 53   
   -   5         ��Name$ txtKassaNaam��53   H   $��3��6^   $
��Left=�6n   $��23��6�   $��2��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,10.48,0,4.44q�6�   {�6   �� *	KassaNaam+��62   �� *Naam+6�   �� 54   
   -   5        $ txtKassaLocatie��54   N   $��3��6g   $
��Left=�6w   $��23��6�   $��4��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,10.48,0,4.44q�6�   {�6   �� *KassaLocatie+��65   �� *	Locatie+6�   �� 55   
   -   5        $ txtKassaToestel��55   N   $��3��6g   $
��Left=�6w   $��23��6�   $��6��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,9.44,0,5.48q�6�   {�6   �� *KassaToestel+��65   �� *	Toestel+6�   �� 56   
   -   5        $ lstKassaAanmeldingen��56   _   $��3��6}   $
��Left=�6�   $��179.6��6�   $��8��6�   $��5��6�   $	��Top=�6�   $	��488��6�   $��2��6�   $��0,10,0,0q�6  {�6   �� *KassaAanmeldLijst+��6:   �� *Aanmeldlijst+6  �� 57   
   -   5        $ lblKassaNaam��57      $
��Naam��6&   $��3��65   $
��Left=�6E   $��1��6`   $��Center=�6m   $
��23.9��6�   $��75.86��6�   $��0,10.03,0,3.99q�6�   �� 58   
   -   5        $ lblKassaLocatie��58      $��Locatie��6)   $��3��6;   $
��Left=�6K   $��3��6f   $��Center=�6s   $��
0,9,0,2.96q�6�   �� 59   
   -	   5        $ lblKassaToestel��59      $��Toestel��6)   $��3��6;   $
��Left=�6K   $��5��6f   $��Center=�6s   $��
0,9,0,2.96q�6�   �� 5:   
   -
   5        $ lblKassaAameldingen��5:      $��Lijst met aanmeldingen��6-   $��3��6N   $
��Left=�6^   $��7��6y   $��Center=�6�   $��
0,7.96,0,4q�6�   5;      5<      