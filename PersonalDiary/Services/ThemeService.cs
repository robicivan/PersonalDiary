namespace PersonalDiary.Services
{
    public class ThemeService
    {
        public bool IsDark { get; private set; } = false;

        public event Action? OnThemeChanged;

        public void SetTheme(bool isDark)
        {
            IsDark = isDark;
            OnThemeChanged?.Invoke();
        }

        public void Toggle()
        {
            SetTheme(!IsDark);
        }
    }
}
