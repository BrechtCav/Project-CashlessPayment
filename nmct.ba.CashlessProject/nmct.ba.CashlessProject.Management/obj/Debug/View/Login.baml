   M S B A M L   `   `   `  ����]  Ynmct.ba.CashlessProject.Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel,nmct.ba.CashlessProject.Management.ViewModel  5      m;clr-namespace:nmct.ba.CashlessProject.Management.Converters-nmct.ba.CashlessProject.Management.Converters  5      3    -nmct.ba.CashlessProject.Management.View.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ivm:clr-namespace:nmct.ba.CashlessProject.Management.ViewModel     5      Ip;clr-namespace:nmct.ba.CashlessProject.Management.Converters     5        � DataContext  5
      :  4nmct.ba.CashlessProject.Management.ViewModel.LoginVM  5   
    � 	Resources 5      H  Bnmct.ba.CashlessProject.Management.Converters.PasswordBoxAssistant   PasswordBoxAssistant��%   &	          5   
   6!   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      .+�5*   
   �� $��38.4,2,206.4,46q�6,   $��3��6E   $��2��6Y   $��6��6i   $��16(�6v   $��2��6�   ��6   �� *
Username+6�   G� 5+   
   -   5         G�Name$ PasswordBox��5+         BindPassword . $��2��5,   �   $��38.4,2,206.4,46q�6�   $��8��6�   $��3��6�   $��16(�6�   $��2��6�      BoundPassword 63   ��  �� Path$ Password� �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5-   
   $��3��6   $��11��6%   $��2��67   $��2��6D   
���   �$��2q�6h   $��0.4,2,0.4,46q�6|   �� 5.   
   $��3��6   $��3��6%   $��10��66   $��2��6D   $��2q�6T   ���	#FFE3E3E3$��0.4,2,0.4,46q�6   �� 5/   
   $��	Aanmelden��6   $��214.4,17,30.4,22q�6F   $��3��6`   $��10��6p   $��2��6~   $��2��6�   
���������6%   �� *LoginCommand+6�   �� 50   
   
���  ��$��2��6<   $��38.4,7,206.4,31q�6L   $��9��6e   $��2��6r   $��3��6�   ��6%   �� *Error+6�   �� 51   
   $��2��6   $
��Left=�6%   $��38.4,39,0,0q�6@   $��4��6U   $
��Wrap=�6b   $	��Top=�6v   $	��206��6�   $��2��6�   $��39��6�   $��20(�6�   $��2��6�   �� 6�   $�Login��6�   �� 6�   $�:��6�   6�   �� 52   
   $��2��6   $
��Left=�6%   $��
38.4,8,0,0q�6@   $��7��6T   $
��Wrap=�6a   $	��Top=�6u   $	��244��6�   $��2��6�   $��39��6�   $��20(�6�   �� 6�   $�Paswoord��6�   �� 6�   $�:��6�   6�   �� 53   
   $��2��6   $
��Left=�6$   $��	2.4,3,0,0q�6?   $��2��6R   $
��Wrap=�6_   $��Management Login��6s   $	��Top=�6�   $��2��6�   $��3��6�   $��75��6�   $	��728��6�   $��40(�6�   
 �� TextAlignment$
 Center=�6�   
����������	#FFB0CF446  �� 54   
   $��2��6   $
��Left=�6%   $��198.4,35,0,0q�6@   $��13��6V   $��2��6d   $
��Wrap=�6u   $	��Top=�6�   $	��369��6�   $��39��6�   $F��@Designed and programmed by Brecht caveye  - All Rights Reserveed��6�   $��3��6  55      56      