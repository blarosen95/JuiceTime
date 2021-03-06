﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls.Primitives;
using JuiceTime.Views;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JuiceTime
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {

        internal RecipePage RecipeView = new RecipePage();
        internal NotesPage NotesView = new NotesPage();

        public MainPage()
        {
            InitializeComponent();
        }

        //Open the file browser dialog
        private async void Open_OnClick(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List, SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            //Either replace this with a custom File Explorer view or ensure that this directory is ultimately always remembered
            picker.FileTypeFilter.Add(".json");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                //Application now has read/write access to the picked file
                //TODO: Call the JSON Parser class and store the data parsed from the file in a List
                var recipeJson = await FileIO.ReadTextAsync(file);
                var recipeFromFile = JsonConvert.DeserializeObject<Recipe>(recipeJson);
                NotesView.NotesTextBox.Text = RecipeView.CreateDataFromRecipe(recipeFromFile);
            }
            else
            {
                //The picker was likely cancelled by the user
                //TODO: Either inform them (only obvious result would be user annoyance/frustration) or, ideally, just do nothing here.
                return;
            }
        }

        //Open the file saving dialog/browser, perform parsing/processing, and save as instructed by user input
        private async void Save_OnClick(object sender, RoutedEventArgs e)
        {
            var picker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeChoices.Add("JSON File", new List<string>() { ".json" });
            picker.SuggestedFileName = "New Recipe";

            //TODO: The suggested start location (user's Documents folder) does indeed only open as default until the user has saved to another folder
            // TODO (continued): once they have saved to another folder, it appears to remember that even after closing the App and later restarting it (at least in VS's debug)

            var file = await picker.PickSaveFileAsync();
            if (file == null) return;
            //Prevent updates to the remote version of this file until changes are finalized and CompleteUpdatesAsync is called
            CachedFileManager.DeferUpdates(file);

            var recipeToGo = RecipeView.CreateRecipeFromData(NotesView.NotesTextBox.Text);
                
            //TODO: This is creating a string with just "{}" none of the data seems to exist.
            var recipeJson = JsonConvert.SerializeObject(recipeToGo);

            //Write to file
            await FileIO.WriteTextAsync(file, recipeJson);
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e) => Application.Current.Exit();

//        private Recipe GetRecipe()
  //      {
    //        return new Recipe();
     //   }

        #region NavigationView event Handlers
        private void NvTopLevelNav_Loaded(object sender, RoutedEventArgs e)
        {
            //Set initial page
            foreach (NavigationViewItemBase item in nvTopLevelNav.MenuItems)
            {
                if (!(item is NavigationViewItem) || item.Tag.ToString() != "Recipe_Page") continue;
                nvTopLevelNav.SelectedItem = item;
                break;
            }

            contentFrame.Content = RecipeView;

        }

        private void NvTopLevelNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void NvTopLevelNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (!(args.InvokedItem is TextBlock itemContent)) return;
            switch (itemContent.Tag)
            {
                case "Nav_Recipe":
                    contentFrame.Content = RecipeView;
                    break;

                case "Nav_Notes":
                    contentFrame.Content = NotesView;
                    break;

                case "Nav_Calculator":
                    var calculateView = new CalculatePage(RecipeView.CreateRecipeFromData(NotesView.NotesTextBox.Text));
                    //Calculate the values before bringing the page into view
                    calculateView.CalculateValues();
                    contentFrame.Content = calculateView;
                    break;
            }
        }
        #endregion

        private void GramsSet_OnClick(object sender, RoutedEventArgs e)
        {
            var p = new Popup {Child = new Views.GramsPage(), IsOpen = true};
        }
    }
}
