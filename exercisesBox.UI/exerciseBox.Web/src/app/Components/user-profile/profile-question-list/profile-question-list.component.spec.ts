import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileQuestionListComponent } from './profile-question-list.component';

describe('ProfileQuestionListComponent', () => {
  let component: ProfileQuestionListComponent;
  let fixture: ComponentFixture<ProfileQuestionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfileQuestionListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfileQuestionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
