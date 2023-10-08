import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './component/Header';
import Footer from './component/Footer';
import PatientRegistration from './component/PatientRegistration';
import Home from './component/Home';
import PatientLogin from './component/PatientLoginFeel';
import MakeAppointment from './component/MakeAppointment';
import AppointmentList from './component/AppointmentList';
import { Box, Container } from '@mui/material';
import { UserProvider } from './component/common/UserContext';
import { ToastContainer } from 'react-toastify';

function App() {
    return (
      <UserProvider>
        <Router>
        <Box display="flex" flexDirection="column" minHeight="100vh">
        <ToastContainer />
        <Header />
      <Container  component="main" maxWidth="md">
          <Box  p={3} style={{ marginTop: '50px', marginBottom: '50px' }}>
                          <Routes>
                              
                              <Route exact path="/" element= {<Home/>}/>
                              <Route path="/register" element= {<PatientRegistration/>}/>
                              <Route path="/login" element= {<PatientLogin/>}/>
                              <Route path="/make-appointment" element= {<MakeAppointment/>}/>
                              <Route path="/list-appointments" element= {<AppointmentList/>}/>
                          </Routes>
          </Box>
          </Container>
          <Footer />
          </Box>
        </Router>
        </UserProvider>
            );
}

export default App;
