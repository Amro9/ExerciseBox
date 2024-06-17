import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class QuestionFromService {

  constructor(
    private http: HttpClient,
  ) { }

  submitQuestionForm( formData: FormData) {
    let url_ = "http://localhost:7292/addQuestion";
    
    this.http.post(url_, formData)
    .subscribe(
      response => {
        console.log('Form data submitted successfully!', response);
        // Handle successful form submission (e.g., clear form, show success message)
      },
      error => {
        console.error('Error submitting form data:', error);
        // Handle form submission error (e.g., show error message)
      }
    );
}}
