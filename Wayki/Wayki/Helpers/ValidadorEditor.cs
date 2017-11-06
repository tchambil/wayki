﻿using System;
using Xamarin.Forms;
using System.Text.RegularExpressions;
namespace Wayki.Helpers
{
    public class ValidadorEditor : Behavior<Editor>
    {
        //Result message
        public static readonly BindableProperty MessageProperty = BindableProperty.Create("Message", typeof(string), typeof(ValidadorEditor), string.Empty);
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            private set { SetValue(MessageProperty, value); }
        }

        private static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("EsValido", typeof(bool), typeof(ValidadorEditor), false);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;
        public bool EsValido
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            private set
            {
                SetValue(IsValidPropertyKey, value);
            }
        }

        private static readonly BindablePropertyKey MostrarMensajeKey = BindableProperty.CreateReadOnly("MostrarMensaje", typeof(bool), typeof(ValidadorEditor), false);
        public static readonly BindableProperty MostrarMensajeProperty = MostrarMensajeKey.BindableProperty;
        public bool MostrarMensaje
        {
            get
            {
                return !EsValido && string.IsNullOrEmpty(Message);
            }
        }


        public static readonly BindableProperty EsTextoProperty = BindableProperty.Create("EsTexto", typeof(bool), typeof(ValidadorEditor), false);
        public bool EsTexto
        {
            get { return (bool)GetValue(EsTextoProperty); }
            set { SetValue(EsTextoProperty, value); }
        }
        public static readonly BindableProperty EsCorreoProperty = BindableProperty.Create("EsCorreo", typeof(bool), typeof(ValidadorEditor), false);
        public bool EsCorreo
        {
            get { return (bool)GetValue(EsCorreoProperty); }
            set { SetValue(EsCorreoProperty, value); }
        }

        protected override void OnAttachedTo(Editor entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            EsValido = false;
            Message = "";
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Editor entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        public bool Validar(string texto)
        {
            if (EsTexto)
            {
                EsValido = !string.IsNullOrWhiteSpace(texto);
                if (!EsValido)
                {
                    Message = "Debe ingresar un texto.";
                }
                else
                {
                    var NombreRegex = @"^[\p{L} \.'\-]+$";
                    EsValido = (Regex.IsMatch(texto, NombreRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                    if (!EsValido)
                    {
                        Message = "Debe ingresar un texto válido.";
                    }
                }
            }
            if (EsCorreo)
            {
                var EmailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                EsValido = (Regex.IsMatch(texto, EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                if (!EsValido)
                {
                    Message = "Debe ingresar un correo válido.";
                }
            }
            if (EsValido)
            {
                Message = string.Empty;
            }
            return EsValido;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            Validar(args.NewTextValue);
        }
    }
}
