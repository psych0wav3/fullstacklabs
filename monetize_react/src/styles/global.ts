import {createGlobalStyle} from 'styled-components';

export const Global = createGlobalStyle`
  body{
    width: 100%;
    height: 100vh;
    padding: 0;
    margin: 0;
    font-size: 16px;
    background-color: ${({theme}) => theme.colors.background};
    font-family: 'Poppins', sans-serif;
  }
`