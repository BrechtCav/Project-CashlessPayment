   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Management.Converters-nmct.ba.CashlessProject.Management.Converters  5      8    2nmct.ba.CashlessProject.Management.View.Medewerker   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Cp;clr-namespace:nmct.ba.CashlessProject.Management.Converters  5        � DataContext  5      ?  9nmct.ba.CashlessProject.Management.ViewModel.MedewerkerVM  5   
    � 	Resources 5      D   >nmct.ba.CashlessProject.Management.Converters.BoolToVisibility   BoolToVisibility��%   &	          5   
   6   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��244* �6   �� 5      $
��244* �6   �� 5      $
��244* �6   �� 5      $
��245* �6   �� 5      $	��244 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   �� -   5         ��Name$ lblMedewerkerSelecteer��5+      $��Selecteer een medewerker��60   $
��Left=�6S   $��1��6n   $��1��6~   $��Center=�6�   �� 5,   
   -   5         ��Name$ lstMedewerkerSelecteer��5,   �   $
��Left=�6�   $��379.2��6�   $��10��6�   $	��Top=�6�   $	��244��6�   $��1��6  $��2��6   �� SelectedItem 6   �� *SelectedEmployee+��6<   �� *ListEmployees+{�6b   �� *LijstEnable+.  (System.Windows.Interactivity.Interaction   Triggers 5-      /  )System.Windows.Interactivity.EventTrigger  5.         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5/      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *ToonGekozenMedewerker+50      52      �� 53   
   -   5         ��Name$ btnMedewerkerNieuw��53   Q   $��Nieuwe medewerker��6m   $��3��6�   $��1��6�   $��Center=�6�   $	��155��6�   $��25��6�   $
��Left=�6�   ��6   �� *
btnNieuw+{�6/   �� *NieuwEnable+6�   �� 54   
   -   5        $ btnMedewerkerWijzig��54   S   $��Wijzig medewerker��6p   $��4��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6�   $��1��6�   ��6   �� *	btnWijzig+{�60   �� *WijzigEnable+6�   �� 55   
   -   5        $ btnMedewerkerVerwijder��55   Y   $��Verwijder medewerker��6y   $��1��6�   $��13��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6�   $��0,6.46,89,6.46q�6  ��6   �� *btnVerwijder+{�62   �� *Verwijderenable+6  �� 56   
   -   5        $ lblMedewerkerNaam��56      $
��Naam��6+   $��3��6:   $
��Left=�6J   $��2��6e   $��Center=�6r   $
��23.9��6�   $��75.86��6�   $��0,7.03,0,6.99q�6�   �� 57   
   -   5         ��Name$ txtMedewerkerNaam��57   P   $��3��6k   $
��Left=�6{   $��23��6�   $��3��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,7.48,0,7.44q�6�   ��6   �� *EmployeeName+{�60   �� *	TXTEnable+6�   �� 58   
   -   5        $ txtMedewerkerAdres��58   Q   $��3��6m   $
��Left=�6}   $��23��6�   $��5��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��1.4,7.2,0,7.4q�6�   $��2��6  ��6   �� *EmployeeAdres+{�61   �� *	TXTEnable+6  �� 59   
   -	   5        $ txtMedewerkerEmail��59   Q   $��3��6m   $
��Left=�6}   $��23��6�   $��7��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,6.44,0,8.q�6�   ��6   �� *EmployeeEmail+{�61   �� *	TXTEnable+6�   �� 5:   
   -
   5        $ txtMedewerkerTel��5:   O   $��3��6i   $
��Left=�6y   $��23��6�   $��9��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��0,6.44,0,8.48q�6�   ��6   �� *EmployeeTel+{�6/   �� *	TXTEnable+6�   �� 5;   
   -   5        $ lblMedewerkerAdres��5;      $��Adres��6,   $��3��6<   $
��Left=�6L   $��4��6g   $��Center=�6t   $��
0,6,0,5.96q�6�   �� 5<   
   -   5        $ lblMedewerkerEmail��5<      $��Email��6,   $��3��6<   $
��Left=�6L   $��6��6g   $��Center=�6t   $��
0,6,0,5.96q�6�   �� 5=   
   -   5        $  btnMedewerkerWijzigOpslaan��5=   �   $��Opslaan��6�   $��3��6�   $��13��6�   $��Center=�6�   $	��155��6�   $��25��6  $��Center=�6  $��0,6.3,89,6.3q�61  ��6   �� *
btnOpslaan+y�61   �� *OpslaanAnnulerenEnable+ �� 	Converter# [  61  �� 5>   
   -   5        $ btnMedewerkerAnnuleren��5>   �   $��	Annuleren��6�   $��4��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6  $��13��6"  $��	44.5,6.46q�60  ��6   �� *btnAnnuleren+y�62   �� *OpslaanAnnulerenEnable+# [  60  �� 5?   
   -   5        $ lblMedewerkerTel��5?      $
��Tel.��6*   $��3��69   $
��Left=�6I   $��8��6d   $��Center=�6q   $��
0,4.96,0,7q�6�   �� 5@   
   $��3��6   $
��Left=�6$   $��1.4,37.2,0,0q�6?   $��11��6U   $
��Wrap=�6c   $	��Top=�6�   $��3��6�   $��37��6�   $	��488��6�   ���	#FFFF0404$��2��6�   ��6w   �� *FoutMelding+6�   �� 5A   
   -   5        $ txtMedewerkerTel_Copy��5A   Q   $��3��6p   $
��Left=�6�   $��23��6�   $��11��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   $��1.4,10.2,0,4.4q�6�   $��2��6  ��6   �� *EmployeeLogin+{�61   �� *	TXTEnable+6  �� 5B   
   -   5        $ lblMedewerkerTel_Copy��5B      $��Login��6/   $��3��6?   $
��Left=�6O   $��10��6j   $��Center=�6x   5C      5D      