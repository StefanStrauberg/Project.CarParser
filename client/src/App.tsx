import { ThemeProvider, createTheme } from "@mui/material/styles";
import { CssBaseline } from "@mui/material";
import MainPage from "./pages/MainPage";

const theme = createTheme({
  palette: {
    primary: { main: "#2a73ff" },
    secondary: { main: "#4f8dff" },
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <MainPage />
    </ThemeProvider>
  );
}

export default App;
