﻿using System;
using CocosSharp;


namespace DynamicTextures
{
    public class GameAppDelegate : CCApplicationDelegate
    {
        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {

            CCLog.CustomCCLog = new DynamicTexturesLogger();

            application.PreferMultiSampling = true;

            application.ContentRootDirectory = "Content";
           
            CCSize windowSize = mainWindow.WindowSizeInPixels;

            float desiredWidth = 1024.0f;
            float desiredHeight = 768.0f;

            desiredWidth = windowSize.Width;
            desiredHeight = windowSize.Height;

            // This will set the world bounds to be (0,0, w, h)
            // CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
            CCScene.SetDefaultDesignResolution(desiredWidth, desiredHeight, CCSceneResolutionPolicy.ExactFit);
            
            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
            if (desiredWidth < windowSize.Width)
            {
                application.ContentSearchPaths.Add("images/hd");
                CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
            }
            else
            {
                application.ContentSearchPaths.Add("images/ld");
                CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            }
            
            CCScene scene = new CCScene(mainWindow);
            GameLayer gameLayer = new GameLayer();

            scene.AddChild(gameLayer);

            mainWindow.RunWithScene(scene);
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }
    }
}
