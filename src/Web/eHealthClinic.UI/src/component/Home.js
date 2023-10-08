import React from 'react';
import { useUser } from './common/UserContext';
import HomePageForVisitors from './HomePage';
import HomePageForPatients from './HomePageForPatients';

function Home() {
    const { user } = useUser();


    return user ? <HomePageForPatients></HomePageForPatients> : <HomePageForVisitors></HomePageForVisitors>;
}

export default Home;
