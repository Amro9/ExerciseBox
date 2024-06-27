import { Folder } from "./Folder";
import { QuestionPickModel } from "./QuestionPickModel";

export class FolderPickModel {
    folder: Folder;
    IsSelected: boolean;
    QuestionPickModels : QuestionPickModel[];
    constructor(folder: Folder, isSelected: boolean, questionPickModels : QuestionPickModel[]) {
        this.folder = folder;
        this.IsSelected = isSelected;
        this.QuestionPickModels = questionPickModels;
    }
}