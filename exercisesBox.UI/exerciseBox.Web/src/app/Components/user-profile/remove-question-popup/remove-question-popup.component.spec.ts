import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveQuestionPopupComponent } from './remove-question-popup.component';

describe('RemoveQuestionPopupComponent', () => {
  let component: RemoveQuestionPopupComponent;
  let fixture: ComponentFixture<RemoveQuestionPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemoveQuestionPopupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RemoveQuestionPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
