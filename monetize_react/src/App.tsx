import Main from "./pages/Main";
import { Global } from "./styles/global";
import { ThemeProvider } from 'styled-components';
import theme from './styles/theme';

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Main />
      <Global />
    </ThemeProvider>
  )  
}

export default App;
