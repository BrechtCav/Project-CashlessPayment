   M S B A M L   `   `   `  ����]  Ynmct.ba.cashlessproject.Medewerker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.cashlessproject.Medewerker.ViewModel,nmct.ba.cashlessproject.Medewerker.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Medewerker.Converters-nmct.ba.CashlessProject.Medewerker.Converters  5      8    2nmct.ba.cashlessproject.Medewerker.View.Bestelling   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.cashlessproject.Medewerker.ViewModel     5      Ic;clr-namespace:nmct.ba.CashlessProject.Medewerker.Converters     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        � DataContext  5      ?  9nmct.ba.cashlessproject.Medewerker.ViewModel.BestellingVM  5   
    � 	Resources 5      J   Dnmct.ba.CashlessProject.Medewerker.Converters.StringToImageConverter   StringToImageConverter��%   &	          5   
   6#   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      �� 5*      .+�5,   
   �� $��2��6c   $
��Left=�6s   $��1.2,22.4,0,0q�6�   $	��Top=�6�   $	��203��6�   $��2��6�   $��38��6�   $��2��6�   $��1��6�    �� SelectedItem 6   �� *SelectedProduct+��6=   �� *ProductLijst+6�   �� 5-   
   $��	Toevoegen��6/   $��3��6C   $��1��6S   $��4��6g   $��1��6t   $��	10,0,10,0q�6�   ��6   �� *	Toevoegen+6�   �� 5.   
   $��Geselecteerde verwijderen��67   $��3��6[   $��1��6k   $��10��6   $��1��6�   $��	10,0,10,0q�6�   ��6   �� *DeleteProductSale+6�   �� 5/   
   $��˄��6.   $��2��6:   $
��Left=�6J   $��110.2,0.2,0,0q�6e   $��3��6|   $	��Top=�6�   $��38��6�   $��19��6�   ��6   �� *
AmountUp+6�   �� 50   
   $��˅��60   $��2��6<   $
��Left=�6L   $��110.2,18.2,0,0q�6g   $��3��6   $	��Top=�6�   $��38��6�   $��19��6�   ��6   �� *
AmountDown+6�   �� 51   
   $��2��6   $
��Left=�6"   $��37��6=   $��148.2,0.2,0,0q�6I   $��3��6`    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $��55��6�   $��24(�6�    �� TextAlignment$ Center=�6�   ��6�   �� *Amount+6�   �� 52   
   $��1��6   $
��Left=�6$   $��0.4,10.2,0,0q�6?   $��3��6U   $
��Wrap=�6b   $��Aantal:��6v   $	��Top=�6�   $��92��6�   �� 53   
   $��1��6   $
��Left=�6$   $��0.4,32.4,0,0q�6?   $��1��6U   $
��Wrap=�6b   $��Product��6v   $	��Top=�6�   $��92��6�   $��2��6�   �� 54   
   $��2��6   $
��Left=�6$   $��1.2,10.6,0,0q�6?   $��12��6U   $
��Wrap=�6c   $��Totaal:��6w   $	��Top=�6�   $��92��6�   �� 55   
   $��2��6   $
��Left=�6$   $��0.2,12.6,0,0q�6?   $��12��6U   $
��Wrap=�6c   $	��Top=�6w   $��92��6�   �� 56   
   $��Bestelling afronden��68   $��3��6V   $��1��6f   $��13��6z   $��1��6�   $��	10,0,10,0q�6�   ��6   �� *BestellingAfronden+6�   �� 57   
   $��	Annuleren��69   $��2��6M   $��1��6]   $��13��6q   $��1��6   $��	10,0,10,0q�6�   ��6   �� *BestellingAnnuleren+6�   &   System.Windows.Controls.DataGrid  58   
      CanUserAddRows .     AutoGenerateColumns .  $��3��6�   $��1��6�   $��5��6�   $��5��6�   $��
0,10,10,10q�6�    6   �� *SelectedProductSale+��6W   �� *ListProductSale+	   Columns	 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Aantal��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
AmountPR+  5;      $
 Product��6%   $	 300 66    6B   �� *	ProductID+  5<      $
 	Subtotaal��6%   $	 200 68    6D   �� *
Totalprice+5>      �� 5?   
   $��3��6   $
��Left=�6$   $��10,10.6,0,0q�6?   $��12��6T   $
��Wrap=�6b   $	��Top=�6�   $	��136��6�   ��6v   �� *Totaal+6�   �� 5@   
   $��3��6   $
��Left=�6$   $��151,10.6,0,0q�6?   $��12��6U   $
��Wrap=�6c   $	��€��6w   $	��Top=�6�   $��43��6�   �� 5A   
   $��Naam:��6   $��16(�6!    �� TextAlignment$
 Left=�6/   $��2��6E   $��4��6R   $��77,1.8,27.2,9.8q�6b   �� 5B   
   $��16(�69   $
 Left=�6G   $��2��6]   $��4��6j   $��3��6z   $��176,1.8,39.4,10.8q�6�   ��6   �� *LoadedCustomer.Name+6�   �� 5C   
   $��Saldo:��6   $��16(�6"   $
 Left=�60   $��10��6F   $��4��6T   $��77,3.6,27.2,8.8q�6d   �� 5D   
   $��16(�6+   $
 Left=�69   $��10��6O   $��4��6]   $��3��6m   $��176,3.6,39.4,9.8q�6�   ��6   �� *Saldo+6�   �� 5E   
   $��Foto:��6   $��16(�6!   $
 Left=�6/   $��3��6E   $��4��6R   $��77,15.2,27.2,34.8q�6b   $��2��6}   �� 5F   
   $��2��6�   $��4��6�   $��176,15.2,34.2,15.4q�6�   $��3��6�   $��7��6�   ��6   �� *LoadedCustomer.Picture+ �� 	Converter# [   �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5G   
   $��4��6   $
��Left=�6$   $��	0,5.4,0,0q�6?   $��1��6R   $
��Wrap=�6_   $��Klant��6s   $	��Top=�6�   $��20(�6�   �� 5H   
   $��4��6   $��3��6$   $��12��68   $��	80,0,20,0q�6F   $��20(�6w   
���  ����6Y   �� *KlantMelding+6�   �� 5I   
   $��2��6`   $
��Left=�6p   $��	1.2,9,0,0q�6�   $	��Top=�6�   $	��203��6�   $��2��6�   $��38��6�   $��2��6�    6   �� *SelectedCategorie+��6?   �� *	CatList+.  (System.Windows.Interactivity.Interaction   Triggers 5J      /	  )System.Windows.Interactivity.EventTrigger	  5K       	  	EventName$ SelectionChanged��6!   .
  (System.Windows.Interactivity.TriggerBase 
  Actions. 5L      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *GetProductencbo+5M      5O      �� 5P   
   $��1��6   $
��Left=�6$   $��
0.4,21,0,0q�6?   $
��Wrap=�6S   $��	Categorie��6g   $	��Top=�6x   $��92��6�   �� 5Q   
   $��Lees eID��6.   $��5��6A   $��2��6Q   $��1��6e   $��2��6r   $��203.8,1.4,19.4,35.8q�6�   ��6   �� *
EIDLezen+6�   5R      5S      