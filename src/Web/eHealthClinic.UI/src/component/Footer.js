import React from 'react';
import { Box, Typography, Container } from '@mui/material';

function Footer() {
    return (
        <Box 
            component="footer" 
            style={{ 
                backgroundColor: '#a8324a', 
                marginTop: 'auto', 
                padding: '16px 0' 
            }}
        >
            <Container maxWidth="lg">
                <Typography variant="body2" color="textSecondary" align="center">
                    © {new Date().getFullYear()} eHealth Clinic Management System. All rights reserved.
                </Typography>
            </Container>
        </Box>
    );
}

export default Footer;
