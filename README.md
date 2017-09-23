# MvvmLightCrashRepo
A reproduction of a crash with MvvmLight for testing purposes.

This project is an iOS app with a core .NET Standard project, using the pre-release MvvmLight libs. The iOS app has 2 view controllers on a storyboard. CountersView.cs, one of the view controllers, has a + button in the navigation bar and tapping this executes a command on the view model to navigate to CounterView, another view controller.

Tapping this button gives a crash. If I change the code to manually load the view controller from a storyboard and push it, it works. If I change the storyboard so CounterVies is the root it works. If I remove the root from the storyboard and navigate to the CounterView from my AppDelegate on startup it works. The crash only happens when using the navigation service to go from CountersView to CounterView.

Crash output:

```
2017-09-23 19:25:28.431 CountrLight.iOS[49368:16364630] critical: Stacktrace:

2017-09-23 19:25:28.431 CountrLight.iOS[49368:16364630] critical:   at <unknown> <0xffffffff>
2017-09-23 19:25:28.431 CountrLight.iOS[49368:16364630] critical:   at (wrapper managed-to-native) ObjCRuntime.Messaging.void_objc_msgSend_IntPtr_bool (intptr,intptr,intptr,bool) [0x00014] in <acc94c10bcf54981a7b27c2a0c5b6c97>:0
2017-09-23 19:25:28.432 CountrLight.iOS[49368:16364630] critical:   at UIKit.UINavigationController.PushViewController (UIKit.UIViewController,bool) [0x00021] in /Users/builder/data/lanes/5024/152b654a/source/xamarin-macios/src/build/ios/native/UIKit/UINavigationController.g.cs:199
2017-09-23 19:25:28.432 CountrLight.iOS[49368:16364630] critical:   at GalaSoft.MvvmLight.Views.NavigationService.NavigateTo (string,object) [0x00160] in <5a01b67f8bfe4c2ab2a34e622b5e1721>:0
2017-09-23 19:25:28.433 CountrLight.iOS[49368:16364630] critical:   at Countr.Core.ViewModels.CountersViewModel.ShowAddNewCounter () [0x00001] in /Users/JimBennett/GitHub/MvvmLightCrashRepo/CountrLight/CounterLight.Core/ViewModels/CountersViewModel.cs:52
2017-09-23 19:25:28.433 CountrLight.iOS[49368:16364630] critical:   at (wrapper runtime-invoke) object.runtime_invoke_void__this__ (object,intptr,intptr,intptr) [0x0004f] in <6314851f133e4e74a2e96356deaa0c6c>:0
2017-09-23 19:25:28.433 CountrLight.iOS[49368:16364630] critical:   at <unknown> <0xffffffff>
2017-09-23 19:25:28.433 CountrLight.iOS[49368:16364630] critical:   at (wrapper managed-to-native) System.Reflection.MonoMethod.InternalInvoke (System.Reflection.MonoMethod,object,object[],System.Exception&) [0x00016] in <6314851f133e4e74a2e96356deaa0c6c>:0
2017-09-23 19:25:28.433 CountrLight.iOS[49368:16364630] critical:   at System.Reflection.MonoMethod.Invoke (object,System.Reflection.BindingFlags,System.Reflection.Binder,object[],System.Globalization.CultureInfo) [0x00032] in /Library/Frameworks/Xamarin.iOS.framework/Versions/11.0.0.0/src/mono/mcs/class/corlib/System.Reflection/MonoMethod.cs:305
2017-09-23 19:25:28.433 CountrLight.iOS[49368:16364630] critical:   at System.Reflection.MethodBase.Invoke (object,object[]) [0x00000] in /Library/Frameworks/Xamarin.iOS.framework/Versions/11.0.0.0/src/mono/mcs/class/referencesource/mscorlib/system/reflection/methodbase.cs:229
2017-09-23 19:25:28.433 CountrLight.iOS[49368:16364630] critical:   at GalaSoft.MvvmLight.Helpers.WeakAction.Execute () [0x0003e] in D:\GalaSoft\mydotnet\MVVMLight\source\GalaSoft.MvvmLight\GalaSoft.MvvmLight (PCL)\Helpers\WeakAction.cs:343
2017-09-23 19:25:28.434 CountrLight.iOS[49368:16364630] critical:   at GalaSoft.MvvmLight.Command.RelayCommand.Execute (object) [0x0002b] in D:\GalaSoft\mydotnet\MVVMLight\source\GalaSoft.MvvmLight\GalaSoft.MvvmLight (PCL)\Command\RelayCommand.cs:228
2017-09-23 19:25:28.434 CountrLight.iOS[49368:16364630] critical:   at GalaSoft.MvvmLight.Helpers.ExtensionsApple/<>c__DisplayClass9_0.<GetCommandHandler>b__0 (object,System.EventArgs) [0x00015] in <5a01b67f8bfe4c2ab2a34e622b5e1721>:0
2017-09-23 19:25:28.434 CountrLight.iOS[49368:16364630] critical:   at UIKit.UIBarButtonItem/Callback.Call (Foundation.NSObject) [0x00010] in /Users/builder/data/lanes/5024/152b654a/source/xamarin-macios/src/UIKit/UIBarButtonItem.cs:30
2017-09-23 19:25:28.434 CountrLight.iOS[49368:16364630] critical:   at (wrapper runtime-invoke) <Module>.runtime_invoke_void__this___object (object,intptr,intptr,intptr) [0x00022] in <acc94c10bcf54981a7b27c2a0c5b6c97>:0
2017-09-23 19:25:28.434 CountrLight.iOS[49368:16364630] critical:   at <unknown> <0xffffffff>
2017-09-23 19:25:28.434 CountrLight.iOS[49368:16364630] critical:   at (wrapper managed-to-native) UIKit.UIApplication.UIApplicationMain (int,string[],intptr,intptr) [0x0005c] in <acc94c10bcf54981a7b27c2a0c5b6c97>:0
2017-09-23 19:25:28.435 CountrLight.iOS[49368:16364630] critical:   at UIKit.UIApplication.Main (string[],intptr,intptr) [0x00005] in /Users/builder/data/lanes/5024/152b654a/source/xamarin-macios/src/UIKit/UIApplication.cs:79
2017-09-23 19:25:28.435 CountrLight.iOS[49368:16364630] critical:   at UIKit.UIApplication.Main (string[],string,string) [0x00038] in /Users/builder/data/lanes/5024/152b654a/source/xamarin-macios/src/UIKit/UIApplication.cs:63
2017-09-23 19:25:28.435 CountrLight.iOS[49368:16364630] critical:   at CountrLight.iOS.Application.Main (string[]) [0x00001] in /Users/JimBennett/GitHub/MvvmLightCrashRepo/CountrLight/iOS/Main.cs:17
2017-09-23 19:25:28.435 CountrLight.iOS[49368:16364630] critical:   at (wrapper runtime-invoke) <Module>.runtime_invoke_void_object (object,intptr,intptr,intptr) [0x00051] in <5f74c3c9ba99485f85d0be385dc91ee1>:0
2017-09-23 19:25:28.435 CountrLight.iOS[49368:16364630] critical: 
Native stacktrace:

2017-09-23 19:25:28.441 CountrLight.iOS[49368:16364630] critical: 	0   CountrLight.iOS                     0x0000000106a738e4 mono_handle_native_crash + 244
2017-09-23 19:25:28.441 CountrLight.iOS[49368:16364630] critical: 	1   CountrLight.iOS                     0x0000000106a81250 mono_sigsegv_signal_handler + 288
2017-09-23 19:25:28.442 CountrLight.iOS[49368:16364630] critical: 	2   libsystem_platform.dylib            0x00000001155aab3a _sigtramp + 26
2017-09-23 19:25:28.442 CountrLight.iOS[49368:16364630] critical: 	3   ???                                 0x0000000000000018 0x0 + 24
2017-09-23 19:25:28.442 CountrLight.iOS[49368:16364630] critical: 	4   CoreFoundation                      0x000000010722932d -[NSArray initWithArray:range:copyItems:] + 445
2017-09-23 19:25:28.442 CountrLight.iOS[49368:16364630] critical: 	5   UIKit                               0x000000010b4c6ab5 -[UIViewController(UIContainerViewControllerProtectedMethods) childViewControllers] + 56
2017-09-23 19:25:28.442 CountrLight.iOS[49368:16364630] critical: 	6   UIKit                               0x000000010b4af9c2 __42-[UIViewController _transitionCoordinator]_block_invoke_2 + 173
2017-09-23 19:25:28.442 CountrLight.iOS[49368:16364630] critical: 	7   UIKit                               0x000000010b4af579 -[UIViewController _transitionCoordinator] + 553
2017-09-23 19:25:28.442 CountrLight.iOS[49368:16364630] critical: 	8   UIKit                               0x000000010b4d0952 -[UINavigationController _transitionCoordinator] + 197
2017-09-23 19:25:28.443 CountrLight.iOS[49368:16364630] critical: 	9   UIKit                               0x000000010b4eaf4e -[UINavigationController pushViewController:animated:] + 148
2017-09-23 19:25:28.443 CountrLight.iOS[49368:16364630] critical: 	10  CountrLight.iOS                     0x0000000106c44f49 xamarin_dyn_objc_msgSend + 217
2017-09-23 19:25:28.443 CountrLight.iOS[49368:16364630] critical: 	11  ???                                 0x0000000134909437 0x0 + 5176857655
2017-09-23 19:25:28.443 CountrLight.iOS[49368:16364630] critical: 
=================================================================
Got a SIGSEGV while executing native code. This usually indicates
a fatal error in the mono runtime or one of the native libraries 
used by your application.
=================================================================
```
