   M S B A M L   `   `   `  ����E  AMonitorGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MonitorGUI
MonitorGUI  5   	       MonitorGUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MonitorGUI     5   	     � Title$  Monitor View��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� $$��Number of external requests : ��6   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   �� 5   
   -   5         ��Name$ 
NbRequests��5      $
��Left=�6$   $��
186,10,0,0q�6?   $	��Top=�6S   �� 5   
   $&�� Current cache expiration time : ��6   $
��Left=�6;   $��	10,41,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $  CurrentCacheExpirationTime��5      $
��Left=�64   $��
191,41,0,0q�6O   $	��Top=�6c   �� 5   
   -   5         ��Name$ CacheExpirationTimeSetter��5      $
��Left=�65   $��23��6P   $��
10,172,0,0q�6\    �� TextWrapping$
 Wrap=�6p   $��Enter a number of seconds��6�   $	��Top=�6�   $	��202��6�   �� 5   
   $"��Set cache expiration time : ��6   $
��Left=�67   $��
10,141,0,0q�6R   $	��Top=�6f   �� 5   
   -   5         ��Name$ 	SetButton��5      $	��Set��6$   $
��Left=�62   $	��Top=�6M   $��43��6e   $��217,172,0,0q�6p   6�   �� 5   
   -   5        $ RefreshButton��5      $��Refresh��6(   $
��Left=�6:   $	��Top=�6U   $��75��6m   $��	10,72,0,0q�6x   6�   �� 5   
   $!��Number of cache requests : ��6   $
��Left=�66   $��
292,10,0,0q�6Q   $	��Top=�6e   �� 5   
   -   5        $ NbCacheRequests��5      $
��Left=�6)   $��
455,10,0,0q�6D   $	��Top=�6X   �� 5   
   -   5         ��Name$ CacheMonitoring��5      $
��Left=�6+   $	��185��6F   $��292,107,0,0q�6S   $	��Top=�6h   $	��335��6�   �� 5   
   $$��Cities currently in the cache:��6   $
��Left=�69   $��
292,76,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ 
ErrorLabel��5      $�� ��6$   $
��Left=�6/   $��
10,200,0,0q�6J   $	��Top=�6^   
���  ��6v   5      5      