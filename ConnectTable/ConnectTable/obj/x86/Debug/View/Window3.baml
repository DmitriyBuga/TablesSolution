   M S B A M L   `   `   `  ����  MvvmExample    MvvmExample.View.Window3   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   ,    � Title$ Window3��5   	   $	��500��6   $	��400��6&   .��5      �  � RowDefinitions 5   
   �� 5      $��0.939* �6   �� 5      $
��Auto �6   .+�5
   
   �� $��POCO ViewModel��6   $��Center=�6+   $��Center=�6H   .��5      �  5      �� 5      �� 5      $
��Auto �6(   .+�5      �� $
��Auto=�6#   .��5      �� .+�5      ��  �� DisplayMemberPath$ 	FirstName��6m   $��5q�6�   $
��Left=�6�   ��6&   �� *People+ �� SelectedItem 6E   �� *SelectedPerson+6�   &   System.Windows.Controls.DataGrid  5      $��5q�6n   $
��Left=�6y   ��6'   �� *People+ 6F   �� *SelectedPerson+6y   �� 5      $ 	FirstName��6n   $��5q�6�   ��6'   �� *People+ 6F   �� *SelectedPerson+6�   �� 5      -   5         ��Name$	 tb1��5   &   $��5q�6w   ��63   �� *TextProperty1+ �� UpdateSourceTrigger$ PropertyChanged=�6w   �� 5      $
��Bold"�6(   $
��Wrap=�6:   $��5q�6N   $��The TextBox says '��6Y   �� 6t   �6x   �� *TextProperty1+�� 6�   $*�$', but it should be showing the time��6�   6�   5      5      �� 5      $��1��6   $��
Add Person��6*   $��5q�6�   |�.  ��6?   �� *AddUserCommand+��6b   ��  �� Path$
 Text� �� ElementName$	 tb1��6�   5      5      �� 5      $��Next example��6   $	��Top=�6,   $��Right=�6D   $
��Bold"�6`   
���  ��$��1��6�   $��5q�6�   ��6�   �� *NextExampleCommand+5      5      