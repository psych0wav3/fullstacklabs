import React, { useEffect, useState } from 'react';
import logo from '../../assets/logo.svg';
import * as M from './styles';
import Modal from 'react-modal';
import { GiReturnArrow } from 'react-icons/gi';
import api, { Endpoint } from '../../services/api';
import {Balance, Currency, Moviments, NewBalancePayload, Type} from './types';

const Main: React.FC = () => {

  const [isOpen, setIsOpen] = useState<boolean>(false);
  const [isOpenConvert, setIsOpenConvert] = useState<boolean>(false);
  const [newBalance, setNewBalance] = useState<string>('');
  const [balances, setBalances] = useState<Balance[]>([]);
  const [moviments, setmoviments] = useState<Moviments[]>([]);
  const [selectValue, setSelectValue] = useState<string>('');
  const [convertValue, setConvertValue] = useState<string>('');

  useEffect(() => {
    const getBalances = async () => {
      try {
        const response = await api.get(Endpoint.Balance);
        setBalances(response.data)
      } catch (err) {
        alert(err);
      }
    } 
    const getmoviments = async () => {
      try {
        const response = await api.get(Endpoint.Moviments);
        const data: Moviments[] = response.data;
        const formated: Moviments[] = data.map(item => {
          return {
            id: item.id,
            value: item.value,
            type: Type[item.type],
            oldCurrency: Currency[item.oldCurrency],
            newCurrency: Currency[item.newCurrency]
          }
        });
        setmoviments(formated)
      } catch (err) {
        alert(err);
      }
    } 
    getBalances();
    getmoviments()
  }, [])

  const customStyles = {
    content: {
      top: '50%',
      width: '25%',
      height: '25%',
      left: '50%',
      right: 'auto',
      bottom: 'auto',
      marginRight: '-50%',
      transform: 'translate(-50%, -50%)',
    },
  };

  const handleNewBalance = async (): Promise<void> => {
    const formatedBalance = parseFloat(newBalance.replace(',', '.'));

    const payload: NewBalancePayload = {
      Value: formatedBalance,
      Currency: Currency.BRL,
    }
    try {
      await api.put(Endpoint.Balance, payload);
      alert("Deposito feito com sucesso!")
    } catch (err:any) {
      alert(err);
      console.log(err)
    }
  }

  const handleConvertCoin = async (): Promise<void> => {
    const payload = {
      Value: parseFloat(convertValue),
      Currency: parseInt(selectValue),
    }

    try {
      await api.post(Endpoint.Convert, payload);
      alert("valor convertido com sucesso")
    } catch (err) {
      alert("algo deu errado")
    }
  }
  

  return (
    <M.Container>
      <Modal style={customStyles} isOpen={isOpen} onRequestClose={() => setIsOpen(false)} >
        <M.ModalContent>
          <input onChange={(e) => setNewBalance(e.target.value)} type="text" placeholder="Digite um valor" />
          <button onClick={handleNewBalance}>Confirmar</button>
        </M.ModalContent>
      </Modal>
      <Modal style={customStyles} isOpen={isOpenConvert} onRequestClose={() => setIsOpenConvert(false)} >
        <M.ModalContent>
          <input type="text" placeholder="Digite um valor" onChange={(e) => setConvertValue(e.target.value)} />
          <p>De</p>
          <select disabled>
            <option value={0}>BLR</option>
            <option value={1}>USD</option>
            <option value={2}>EUR</option>
          </select>
          <p>Para</p>
          <select onChange={(e) => setSelectValue(e.target.value)}>
            <option value=''></option>
            <option value={1}>USD</option>
            <option value={2}>EUR</option>
          </select>
          <button onClick={handleConvertCoin}>Confirmar</button>
        </M.ModalContent>
      </Modal>
      <M.Header>
        <div className="title">
          <p className="titulo">Monetize</p>
          <img src={logo} alt="Logo" />
        </div>
      <M.CardContainer>
        <M.Card principal>
          <div onClick={() => setIsOpen(true) }>+</div>

          <M.Text principal>BLR</M.Text>
          <M.Text principal>{Intl.NumberFormat('pt-BR', {style: 'currency', currency: 'BRL'}).format(balances[0]?.value)}</M.Text>
          
        </M.Card>
        <M.Card >
        <div onClick={() => setIsOpenConvert(true) }><GiReturnArrow /></div>
          <M.Text>USD</M.Text>
          <M.Text>{Intl.NumberFormat('en', {style: 'currency', currency: 'USD'}).format(balances[1]?.value)}</M.Text>
        </M.Card>
        <M.Card >
        <div onClick={() => setIsOpenConvert(true) }><GiReturnArrow /></div>
          <M.Text>EUR</M.Text>
          <M.Text>{Intl.NumberFormat('de-DE', {style: 'currency', currency: 'EUR'}).format(balances[2]?.value)}</M.Text>
        </M.Card>
      </M.CardContainer>
      </M.Header>
      <M.Content>

        <M.TransactionTable>
          <thead>
            <M.TransactionHead >
              <th>TIPO</th>
              <th>VALOR</th>
              <th>DE</th>
              <th>PARA</th>
            </M.TransactionHead>
          </thead>
          <tbody>
          {moviments && moviments.map(item => (
            <M.TransactionHead key={item.id}>
            <th>{item.type}</th>
            <th>{item.value}</th>
            <th>{item.oldCurrency}</th>
            <th>{item.newCurrency}</th>
          </M.TransactionHead>
          ))}
          </tbody>
          
        </M.TransactionTable>
      </M.Content>
    </M.Container>
  );
}

export default Main;