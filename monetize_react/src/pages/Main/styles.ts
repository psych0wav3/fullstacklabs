import styled from 'styled-components';

interface CardProps {
  principal?: boolean;
  theme: any;
}

interface TextProps {
  principal?: boolean;
  theme: any;
}


export const Container = styled.div`
  display: flex;
  flex-direction: column;
  width: 100%;
  background-color: ${({theme}) => theme.colors.background};
`

export const CardContainer = styled.div`
  width: 100%;
  display: flex;
  margin-top: 1rem;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  top: -7rem;
  justify-content: space-evenly;
  align-items: center;
  @media screen and (max-width: 800px){
    &{
      flex-direction: column;
    }
  }
`

export const Header = styled.div`
  display: flex;
  flex-direction: column;
  .title{
    display: flex;
    flex-direction: row;
  }
  justify-content: flex-start;
  align-items: flex-start;
  width: 100%;
  box-sizing: border-box;
  padding: 1rem 7rem;
  background-color: ${({theme}) => theme.colors.blue};
  .titulo{
    font-weight: 500;
    font-size: 3rem;
    color: ${({theme}) => theme.colors.pink};
    padding: 0;
    margin: 0;
    margin-right: 1rem;
  }
`
export const Card = styled.div<CardProps>`
   width: 25rem;
   height: 20rem;
   padding: 2.5rem;
   @media screen and (max-width: 800px){
    &{
      
      margin-top: 2rem;
    }
  }
   box-sizing: border-box;
   border-radius: 20px;
   display: flex;
   align-items: flex-start;
   flex-direction: column;
   justify-content: center;
   box-shadow: 1px 7px 15px rgba(0,0,0,0.2);
   background-color: ${({principal, theme}) => principal ? theme.colors.gold : theme.colors.lightblue};

   div{
      display: flex;
      align-items: center;
      font-size: 2rem;
      align-self: flex-end;
      border-radius: 20px;
      height: 4rem;
      justify-content: center;
      width: 4rem;
      color: ${({theme}) => theme.colors.white};
      right: auto;
      background-color: ${({theme}) => theme.colors.blue};
   }
`
export const Text = styled.p<TextProps>`
  padding: 0;
  margin: 0;
  font-size: 3rem;
  color: ${({principal, theme}) => principal ? theme.colors.blue : theme.colors.gold};
  font-weight: 500;
`

export const Content = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 3rem;
`

export const TransactionTable = styled.table`
  width: 70%;
  border-collapse: collapse;
`

export const TransactionHead = styled.tr`
  border-radius: 15px;
  border-collapse: collapse;
  th{
    font-size: 1.5rem;
    font-weight: 500;
    color: ${({theme}) => theme.colors.blue};
  }
  td{
    background-color: ${({theme}) => theme.colors.white};
    border-radius: 20px;
    height: 5rem;
  }
`

export const TransactionItem = styled.tr`
  border-radius: 30px;
  margin-top: 1rem;
  background-color: ${({theme}) => theme.colors.white};
  border-radius: 20px;
  height: 5rem;
  td{
    text-align: center;
  }
`

export const ModalContent = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  input{
    border: none;
    border-radius: 15px;
    width: 50%;
    height: 15%;
    outline: none;
    text-align: center;
    color: ${({theme}) => theme.colors.white};
    font-weight: 500;
    background-color: ${({theme}) => theme.colors.lightblue};
  }
  button{
    margin-top: 2rem;
    background-color: ${({theme}) => theme.colors.pink};
    border: none;
    border-radius: 5px;
    width: 50%;
    height: 3rem;
    font-size: 1.2rem;
    outline: none;
    color:${({theme}) => theme.colors.white};
    &:hover{
      filter: brightness(.9);
    }
  }
`