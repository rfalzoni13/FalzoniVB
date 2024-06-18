﻿@If FalzoniVB.Utils.Helpers.ConfigurationHelper.IsBundleled Then
    @<script src="@Url.Content("~/Scripts/libraries/cropper/cropper.min.js")"></script>
    @<script src="@Url.Content("~/Scripts/libraries/select2/select2.min.js")"></script>
    @<script src="@Url.Content("~/Scripts/libraries/jquery-cropper/jquery-cropper.min.js")"></script>
    @Scripts.Render("~/bundles/js/bootstrap-datepicker")
    @Scripts.Render("~/bundles/jquerymask")
Else
    @<script src="https://cdnjs.cloudflare.com/ajax/libs/cropperjs/1.5.7/cropper.min.js" integrity="sha512-N4T9zTrqZUWCEhVU2uD0m47ADCWYRfEGNQ+dx/lYdQvOn+5FJZxcyHOY68QKsjTEC7Oa234qhXFhjPGQu6vhqg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    @<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.8/js/select2.min.js" integrity="sha512-A5lKSoM6p2axvCtNMT5fvLyjuAavxGlfC1YU0Wn8NzWixwutPUCYfymJQLORJ4YFoKIEAqKCN8+MpQQwzi2bjg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    @<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-cropper/1.0.1/jquery-cropper.min.js" integrity="sha512-V8cSoC5qfk40d43a+VhrTEPf8G9dfWlEJgvLSiq2T2BmgGRmZzB8dGe7XAABQrWj3sEfrR5xjYICTY4eJr76QQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    @<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/js/bootstrap-datepicker.min.js" integrity="sha512-cOGL6gI01KK2Bws211W8S3COhzrorBbzKvLPWYOVtSEYet3yG1fzJrimtwh8rUyvMy9qjgY2e7Rt6IwyaiX1Mg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    @<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/locales/bootstrap-datepicker.pt-BR.min.js" integrity="sha512-mVkLPLQVfOWLRlC2ZJuyX5+0XrTlbW2cyAwyqgPkLGxhoaHNSWesYMlcUjX8X+k45YB8q90s88O7sos86636NQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    @<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/locales/bootstrap-datepicker.es.min.js" integrity="sha512-5pjEAV8mgR98bRTcqwZ3An0MYSOleV04mwwYj2yw+7PBhFVf/0KcE+NEox0XrFiU5+x5t5qidmo5MgBkDD9hEw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    @<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js" integrity="sha512-pHVGpX7F/27yZ0ISY+VVjyULApbDlD0/X0rgGbTqCE7WFW5MezNTWG/dnhtbBuICzsd0WQPgpE4REBLv+UqChw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
End If

<script type="text/javascript" src="@Url.Content("~/Scripts/core/datepicker-config.js")"></script>
<script type="text/javascript" src="@Url.Content("~/Scripts/core/image-utils.js")"></script>
<script type="text/javascript" src="@Url.Content("~/Scripts/core/masks.js")"></script>
<script type="text/javascript" src="@Url.Content("~/Scripts/register/customer/form.js")"></script>