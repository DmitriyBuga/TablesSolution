   M S B A M L   `   `   `  ����F  BMvvmExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MvvmExample.HelpersMvvmExample.Helpers  5   2       MvvmExample.View.Window5   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5helpers!clr-namespace:MvvmExample.Helpers     5   2     � WindowStartupLocation$  CenterScreen=�5   ,    � Title$ Window5��5   	   $	��400��6   $	��300��6&    � 	Resources 5      3   -MvvmExample.Helpers.SelectedItemToItemsSource   SelectedItemToItemsSource  UserGrid �� CornerRadius � RowDefinitions � ColumnDefinitions �� BindingGroupName �� UpdateSourceTrigger �� Orientation	 �� RelativeSource
 �� AncestorType��%  &	        &	        5   
   6,   �� 5   
   .R�5      �� 
�������
���   �$��1q�6@   $ 5��6T   $��5q�6e   ._�5	      � $��3q�6    5
      �� 5      �� 5      �� 5      �� 5       5      �� 5      �� 5      .+�5      �� $��
First name��6    �� 5      $��	Last name��6    $��1��61   �� 5      $	��Age��6    $��2��6+   �� 5      $��1��6p   ��6   �� *	FirstName+$ Group1��$ Explicit=�6p   �� 5      $��1��6o   $��1��6   ��6   �� *
LastName+$ Group1��$ Explicit=�6   �� 5      $��1��6j   $��2��6z   ��6   �� *Age+$ Group1��$ Explicit=�6z   �� 5      $ 
Horizontal=�6!   $��3��6:   $��2��6G   $��Right=�6[   .+�5      �� $��Cancel��6!   $	��4,0q�6�   ��62   �� *DataContext.CancelCommand+	 �� $
 ItemsControlL�6�   �� 5      $
��Save��6!   $	��4,0q�6�   ��60   �� *DataContext.SaveCommand+	 �� $
 ItemsControlL�6�   5      5      5      5!      5"      .��5#      �  5$   
   �� 5%      $��0.939* �6   �� 5&      $
��Auto �6   .+�5(   
   �� $#��Business Object via ViewModel��6   $��Center=�6:   $��Center=�6W   .��5)      �  5*      �� 5+      �� 5,      $
��Auto �6$   .+�5.      �� $
��Auto=�6   .��5/      �� .+�50      ��  �� Padding$ 5q�6>   $
��Bold"�6J   $��18(�6\   ��6$   �� *
BoStatus+6\   &   System.Windows.Controls.DataGrid  51      -   5          Name$	 dg1��51   #   $��5q�6w   $
��Left=�6�      CanUserAddRows .     SelectionMode$ Single=�6�   ��60   �� *People+ �� SelectedItem 6O   �� *SelectedPerson+ �� SelectedIndex 6�   �� *SelectedIndex+�� 52      #��[ 6`    � BindingGroup 6'   �� *UpdateBindingGroup+ �� Mode$ OneWay=���6�   �� *SelectedPerson+ �� 	Converter# [  �� 53      -   5         ��Name$	 tb1��53   "   $��5q�6q   ��6/   �� *ReportTitle+$ PropertyChanged=�6q   �� 54      $
��Bold"�6$   $
��Wrap=�66   $��5q�6J   $��The TextBox says '��6U   �� 6p   �6t   �� *ReportTitle+�� 6�   $�'��6�   6�   55      56      �� 57      $��1��6   $��
Add person��6&   $��5q�6^   |�.  ��6;   �� *AddUserCommand+6i   58      59      5:      5;      