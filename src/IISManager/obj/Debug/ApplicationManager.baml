   M S B A M L   `   `   `  ����E  AIISManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IISManager
IISManager  5      #    IISManager.ApplicationManager   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:IISManager     5      .��5
      �� $��Application��6   .��5   
   � -   5          �Name$  RootContainer��5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      .+�5      �� $��Pool Management��6   $��0��64   .��5      �� .+�5      �� $��Start��6!   ��61   �� *)'OnAppPoolStartButtonClickedEventHandler+�� 5      $
��Stop��6!   ��60   �� *(&OnAppPoolStopButtonClickedEventHandler+�� 5      $��Recycle��6!   ��63   �� *+)OnAppPoolRecycleButtonClickedEventHandler+5      5      �� 5      $��1��6   $
��Info��6'   .��5      �� .+�5      �� $��Application pool name : ��6    
�5      �� 5      ��6(   �� *Info.ApplicationPoolName+5      �� 5      $ ��Application pool status : ��6    
�5      �� 5       ��6(   �� *Info.ApplicationPoolStatus+5"      �� 5#      $��Enabled protocols : ��6    
�5$      �� 5%      ��6(   �� *Info.EnabledProtocols+5'      �� 5(      .+�5)      �� $��Virtual directories : ��6$   �� 5*      $��0q�5+      ��5,      �� *Info.VirtualDirectories+��5-      �� 5.   "   .R�5/   &   �� $	��400��50   )   $
��Wrap=�51   )   ��52   )   �� 53   #   ��55      �� 56   "    �� 
TargetType" ��6(   .�57   &   ��  �� Property � �� �� Value 58   *   �� 59   .    �� 
TargetType" ��6>   .R�5:   2   ��  �� Orientation$ 
Horizontal=�6=   .+�5;   6   �� $
��• ��6@   �� 5<   6   $��Center=�6G   $
��Left=�6b   5=   3   5>   /   5@   '   5A   #   5C      5D      5E      5F      5G      5H      5I      