import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionsPoolComponent } from './questions-pool.component';

describe('QuestionsPoolComponent', () => {
  let component: QuestionsPoolComponent;
  let fixture: ComponentFixture<QuestionsPoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestionsPoolComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(QuestionsPoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
