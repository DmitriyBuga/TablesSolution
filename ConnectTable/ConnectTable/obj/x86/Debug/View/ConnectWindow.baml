   M S B A M L   `   `   `  ����G  CConnectTable, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ConnectTable.ViewConnectTable.View  5   	   ?$clr-namespace:ConnectTable.ViewModelConnectTable.ViewModel  5   	   %    ConnectTable.View.ConnectWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   1localclr-namespace:ConnectTable.View     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3vm$clr-namespace:ConnectTable.ViewModel     5   	     � Title$  ConnectWindow��5   	   $	��479��5	   	   $	��300��5
   	      ViewModelConnect � DataContext# �   5   	    � 	Resources 5      -   'ConnectTable.ViewModel.ViewModelConnect��%   &	          5   
   6   5      .��5      � $	��470��6   $
��Left=�6    � ColumnDefinitions 5   
   �� 5      �� 5      $��1 �6   .+�5   
   �� -   5         ��Name$ groupBox��5      $	��461��5      $	��179��5      $��5,4,0,0q�5      $
��Left=�5      $	��Top=�5      $��
Connection��5       J� RenderTransformOrigin$ -1.45,-0.724&�5      �� 5   
   -   5         ��Name$ 	textBlock��5      $	��149��5      $��	12,27,0,0q�5      $
��Left=�5       $	��Top=�5!      $��Select plugin ��5"      $
��Wrap=�5#      �� 5$   
   -   5        $ textBlock_Copy��5$      $	��149��5%      $��	12,55,0,0q�5&      $
��Left=�5'      $	��Top=�5(      $��Connection string��5)      $
��Wrap=�5*      �� 5+   
   -   5         ��Name$ txtDataSource��5+      $	��222��5,      $��21��5-      $��
226,52,0,0q�5.      $
��Left=�5/      $	��Top=�50       �� TextWrapping$
 Wrap=�53      ��51      �� *connectPars.serverName+	 �� Mode$	 TwoWay=�53      �� 54   
   -   5        $ textBlock_Copy1��54      $	��149��55      $��	12,82,0,0q�56      $
��Left=�57      $	��Top=�58      $
��Name��59      $
��Wrap=�5:      �� 5;   
   -   5        $ 	txtUserID��5;      $	��222��5<      $��21��5=      $��
226,79,0,0q�5>      $
��Left=�5?      $	��Top=�5@      $
 Wrap=�5B      ��5A      �� *connectPars.userName+5B      �� 5C   
   -   5        $ textBlock_Copy2��5C      $	��149��5D      $��
12,109,0,0q�5E      $
��Left=�5F      $	��Top=�5G      $��Password��5H      $
��Wrap=�5I      �� 5J   
   -   5        $ txtPassword��5J      $	��222��5K      $��21��5L      $��226,106,0,0q�5M      $
��Left=�5N      $	��Top=�5O      $
 Wrap=�5Q      ��5P      �� *connectPars.password+5Q      �� 5R   
   -	   5        
 ��Name$
 cmbSelectPlugin��5R      $	��225��5S      $��
226,24,0,0q�5T      $
��Left=�5U      $	��Top=�5V      ��5W      �� *listPlugins+ �� SelectedItem 5X      �� *SelectedPlugin+�� 5Y   
   -
   5         ��Name$ cbAuth��5Y      $	��157��5Z      $��18��5[      $��227,134,0,0q�5\      $
��Left=�5]      $	��Top=�5^      $"��Using windows authentication��5_      �� 5`   
   -   5         ��Name$ btnTestConnect��5`      $��75��5a      $��227,153,0,0q�5b      $
��Left=�5c      $	��Top=�5d      $��Connect��5f      {�.  ��5e      �� *ConnectUserCommand+5g      �� 5h   
   -   5        $ 	btnCancel��5h      $��75��5i      $��393,248,0,0q�5j      $
��Left=�5k      $	��Top=�5l      $��Cancel��5n      ��5m      �� *CloseConnectWindowUserCommand+5n      �� 5o   
   -   5        $ btnOpenTable��5o      $��75��5p      $��312,249,0,0q�5q      $
��Left=�5r      $	��Top=�5s      $
��Open��5u      {�.  ��5t      �� *OpenTableUserCommand+5v      �� 5w   
   -   5        $
 cmbDatabases��5w      $	��214��5x      $��230,190,0,0q�5y      $
��Left=�5z      $	��Top=�5{      {�.  ��5}      �� *listDatabases+ 5~      �� *SelectedDatabase+�� 5   
   -   5        $ textBlockDatabase��5      $	��149��5�      $��
17,194,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Select database��5�      $
��Wrap=�5�      �� 5�   
   -   5        $
 	cmbTables��5�      $	��214��5�      $��229,218,0,0q�5�      $
��Left=�5�      $	��Top=�5�      {�.  ��5�      �� *
listTables+ 5�      �� *SelectedTable+�� 5�   
   -   5        $ textBlockTable��5�      $	��149��5�      $��
18,222,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Select table��5�      $
��Wrap=�5�      5�      5�      