import { Injectable } from '@angular/core';
import emailjs from '@emailjs/browser';

@Injectable({
  providedIn: 'root'
})
export class EmailService {
  constructor() {
    // Initialize EmailJS with your public key
    emailjs.init('L4ppUnADTdNE-I6ZB'); // Replace with your actual EmailJS public key
  }

  async sendHelpRequestEmail(userData: any) {
    try {
      const templateParams = {
        to_email: userData.email,
        to_name: userData.name,
        blood_group: userData.bloodGroup,
        hospital_name: 'Central Hospital', // Replace with actual hospital name
        message: `Dear ${userData.name},

We urgently require blood donors of blood group ${userData.bloodGroup} at Central Hospital. As a registered donor with matching blood group, we request your help in this critical situation.

Please contact the hospital blood bank at your earliest convenience.

Location: CareConnect Hospital
Contact: +1-234-567-8900
Blood Bank Hours: 24/7

Your contribution can save a life.

Best regards,
Blood Bank Team
CareConnect Admin
Jhasank Bharadwaj`
      };

      const response = await emailjs.send(
        'service_5y4ique', 
        'template_1yl3mi6', // Replace with your EmailJS template ID
        templateParams
      );

      console.log('Email sent successfully:', response);
      return response;
    } catch (error) {
      console.error('Error sending email:', error);
      throw error;
    }
  }
}