<!-- Main Footer -->
<footer class="main-footer">
    <!-- Default to the left -->
    <strong>Renato Falzoni &copy; <a href="#">2019</a>.</strong> Todos os direitos reservados.
    <div class="pull-right hidden-xs">
        <b>Versão:</b>
        @(GetType(FalzoniVB.Presentation.Administrator.MvcApplication).Assembly.GetName().Version.Major.ToString() +
                                                "." + GetType(FalzoniVB.Presentation.Administrator.MvcApplication).Assembly.GetName().Version.Minor.ToString() +
                                                "." + GetType(FalzoniVB.Presentation.Administrator.MvcApplication).Assembly.GetName().Version.Build.ToString())
    </div>
</footer>
