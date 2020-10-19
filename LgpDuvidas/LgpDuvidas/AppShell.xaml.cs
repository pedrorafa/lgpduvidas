using System;
using System.Collections.Generic;
using LgpDuvidas.ViewModels;
using LgpDuvidas.Views;
using Xamarin.Forms;

namespace LgpDuvidas
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
            }
        }
    }
}
