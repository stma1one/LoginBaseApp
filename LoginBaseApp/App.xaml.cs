﻿using LoginBaseApp.Service;
using LoginBaseApp.Views;

namespace LoginBaseApp
{
    public partial class App : Application
    {
        Page firstpage;
		public App(LoginPage page)
        {
            InitializeComponent();
            this.firstpage = page;
		}

        protected override Window CreateWindow(IActivationState? activationState)
        {
           // return new Window(new AppShell());
           return new Window(firstpage);
		}
    }
}