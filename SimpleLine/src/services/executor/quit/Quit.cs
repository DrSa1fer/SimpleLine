namespace simpleline.services.executor.quit;

internal static class Quit {
    public static void Ok() {
        Environment.Exit(0);
    }

    public static void Fail(int code = -1) {
        Environment.Exit(code);
    }
}