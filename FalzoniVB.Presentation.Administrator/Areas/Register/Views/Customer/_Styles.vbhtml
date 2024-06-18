﻿@If FalzoniVB.Utils.Helpers.ConfigurationHelper.IsBundleled Then
    @Styles.Render("~/bundles/bootstrap-datepicker")
    @Styles.Render("~/bundles/select2")
    @Styles.Render("~/Content/libraries/cropper/cropper.min.css")
Else
    @<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.min.css" integrity="sha512-x2MVs84VwuTYP0I99+3A4LWPZ9g+zT4got7diQzWB4bijVsfwhNZU2ithpKaq6wTuHeLhqJICjqE6HffNlYO7w==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    @<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/css/select2.min.css" integrity="sha512-xrbX64SIXOxo5cMQEDUQ3UyKsCreOEq1Im90z3B7KPoxLJ2ol/tCT0aBhuIzASfmBVdODioUdUPbt5EDEXmD9g==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    @<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/cropperjs/1.5.7/cropper.min.css" integrity="sha512-oG+0IPCSL2awaygM/2l1hPUgHDNnOWji9utPHodoAGbXwLH9yvgD7uRjFxdiKnDr+rx8ejxXYSsUBkcKFR7i0w==" crossorigin="anonymous" referrerpolicy="no-referrer" />
End If