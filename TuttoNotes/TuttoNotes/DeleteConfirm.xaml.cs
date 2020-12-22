﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuttoNotes.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuttoNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteConfirm : ContentPage
    {
        public DeleteConfirm(Note note)
        {
            InitializeComponent();
            BindingContext = note;
        }
    }
}