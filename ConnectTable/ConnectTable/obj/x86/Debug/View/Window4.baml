   M S B A M L   `   `   `  ����  MvvmExample    MvvmExample.View.Window4   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   ,    � Title$ Window4��5   	   $	��450��6   $	��300��6&   .��5      �  � RowDefinitions 5   
   �� 5      $��0.939* �6   �� 5      $
��Auto �6   .+�5
   
   �� $��POCO & ViewModelBase��6   $��Center=�65   $��Center=�6R   .��5      �  5      �� 5      �� 5      $
��Auto �6$   .+�5      �� $
��Auto=�6   .��5      �� .+�5      ��  �� DisplayMemberPath$ 	FirstName��6i   $��5q�6�   $
��Left=�6�   ��6"   �� *People+ �� SelectedItem 6A   �� *SelectedPerson+6�   &   System.Windows.Controls.DataGrid  5      $��5q�6j   $
��Left=�6u   ��6#   �� *People+ 6B   �� *SelectedPerson+6u   �� 5      $ 	FirstName��6j   $��5q�6�   ��6#   �� *People+ 6B   �� *SelectedPerson+6�   �� 5      -   5         ��Name$	 tb1��5   "   $��5q�6s   ��6/   �� *TextProperty1+ �� UpdateSourceTrigger$ PropertyChanged=�6s   �� 5      $
��Bold"�6$   $
��Wrap=�66   $��5q�6J   $��The TextBox says '��6U   �� 6p   �6t   �� *TextProperty1+�� 6�   $�'��6�   6�   5      5      �� 5      $��1��6   $��
Add Person��6&   $��5q�6�   |�.  ��6;   �� *AddUserCommand+��6^   ��  �� Path$
 Text� �� ElementName$	 tb1��6�   5      5      �� 5   
   $��Next example��6   $	��Top=�6(   $��Right=�6@   $
��Bold"�6\   
���  ��$��1��6   $��5q�6�   ��6�   �� *NextExampleCommand+5      5      