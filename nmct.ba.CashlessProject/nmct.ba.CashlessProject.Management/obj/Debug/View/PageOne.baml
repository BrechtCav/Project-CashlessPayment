   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Management.Converters-nmct.ba.CashlessProject.Management.Converters  5      5    /nmct.ba.CashlessProject.Management.View.PageOne   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      Cp;clr-namespace:nmct.ba.CashlessProject.Management.Converters  5        � DataContext  5      <  6nmct.ba.CashlessProject.Management.ViewModel.PageOneVM  5   
    � 	Resources 5      D   >nmct.ba.CashlessProject.Management.Converters.BoolToVisibility   BoolToVisibility��%   &	          5   
   6   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   �� -   5         ��Name$ lblSelecteerCategorie��5+      $��Selecteer een categorie��6/   $
��Left=�6Q   $��1��6l   $��1��6|   $��Center=�6�   �� 5,   
   -   5         ��Name$ cboSelecteerCategorie��5,   �   $	��244��6�   $��1��6�   $��2��6�   $��Center=�6�   $
��Left=�6�   $��25��6  {�6   �� *CategorieLijst+ �� SelectedItem 68   �� *ProductCategorie+��6b   �� *	Categorie+.  (System.Windows.Interactivity.Interaction   Triggers 5-      /  )System.Windows.Interactivity.EventTrigger  5.         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5/      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *GetProductencbo+50      52      �� 53   
   -   5        $ lblSelecteerProduct��53      $��Selecteer een product��6-   $
��Left=�6M   $��1��6h   $��3��6x   $��Center=�6�   6�   �� 54   
   -   5         ��Name$ lstSelecteerProduct��54      $
��Left=�6�   $��303.36��6�   $��8��6�   $	��Top=�6�   $	��244��6�   $��1��6�   $��4��6  {�6   �� *Productlijst+ 65   �� *GekozenProduct+��6]   �� *	Producten+ 55        56      $ SelectionChanged��6!   .	 57        
 6,   �� *ToonGekozenProductlst+58      5:      �� 5;   
   -   5         ��Name$ btnNieuwProduct��5;   [   $��Nieuw product��6t   $��3��6�   $��1��6�   $��Center=�6�   $	��155��6�   $��25��6�   $
��Left=�6�   ��6   �� *NieuwProductButton+{�68   �� *NieuwProduct+6�   �� 5<   
   -   5        $ btnWijzigProduct��5<   ]   $��Wijzig product��6w   $��4��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6�   $��1��6�   ��6   �� *WijzigProductButton+{�69   �� *WijzigProduct+6�   �� 5=   
   -   5        $ btnVerwijderProduct��5=   d   $��Verwijder product��6�   $��1��6�   $��13��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6�   $��0,6.46,89,6.46q�6  ��6   �� *VerwijderGekozenProduct+{�6=   �� *VerwijderProduct+6  �� 5>   
   -   5        $ lblProductNaam��5>      $
��Naam��6(   $��3��67   $
��Left=�6G   $��3��6b   $��Center=�6o   $
��23.9��6�   $��75.86��6�   �� 5?   
   -	   5         ��Name$ txtProductNaam��5?   R   $��3��6j   $
��Left=�6z   $��23��6�   $��4��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $	��244��6�   {�6   �� *InfoProduct+��64   �� *ProductNaam+6�   �� 5@   
   -
   5        $ txtProductPrijs��5@   T   $��3��6m   $
��Left=�6}   $��23��6�   $��6��6�   $
 Wrap=�6�   $��Center=�6�   $	��244��6�   {�6   �� *InfoProduct+��65   �� *ProductPrijs+6�   �� 5A   
   -   5        $" cboSelecteerProductCategorie��5A   �   $��3��6�   $
��Left=�6�   $��8��6�   $��Center=�6�   $	��244��6  $��0.4,8.6,0,8.8q�6  $��2��6,  {�6   �� *InfoProduct+ 67   �� *CategorieProduct+��6a   �� *CategorieProductList+6,  �� 5B   
   -   5        $ lblProductPrijs��5B      $��Prijs��6)   $��3��69   $
��Left=�6I   $��5��6d   $��Center=�6q   �� 5C   
   -   5        $ lblProductCategorie��5C      $��	Categorie��6-   $��3��6A   $
��Left=�6Q   $��7��6l   $��Center=�6y   �� 5D   
   -   5        $ btnProductOpslaan��5D   �   $��Opslaan��6�   $��3��6�   $��13��6�   $��Center=�6�   $	��155��6�   $��25��6  $��Center=�6  $��0,6.46,89,6.46q�6,  ��6   �� *OpslaanProductenButton+y�6=   �� *OpslaanProduct+ �� 	Converter# [  6,  �� 5E   
   -   5        $ btnProductAnnuleren��5E   �   $��	Annuleren��6�   $��4��6�   $��Center=�6�   $	��155��6�   $��25��6�   $��Center=�6  $��13��6%  $��	44.5,6.46q�63  ��6   �� *AnnulerenProductButton+y�6=   �� *AnnulerenProduct+# [  63  �� 5F   
   $��3��6   $
��Left=�6$   $��0.4,10.6,0,0q�6?   $��10��6U   $
��Wrap=�6c   $	��Top=�6�   $��2��6�   $	��244��6�   
���  ����6w   �� *FoutMelding+6�   5G      5H      