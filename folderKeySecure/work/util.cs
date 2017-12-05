namespace folderKeySecure.work {
    class util {
        #if DEBUG
                public const string path = @"D:\development\securetor-windows\folderKeySecure\data\";
                public const string pathApp = path;
        #else
            public const string path = @"\\10.10.14.13\share\П3-15\";
            public const string pathApp = path + @"ignatov_hidden\s\lcr\";
        #endif
    }
}
