# extraordinaire
A fun game made by all the homies

## Getting your development environment set up

The first step to working on the game is getting it on your computer and all set up for writing code.

- First, get a license and install Unity, either of the [personal](https://store.unity.com/products/unity-personal) or the [student](https://unity.com/products/unity-student) licenses should be fine.

- Next, you can pull the code from this remote repository onto your computer:

```bash
git clone https://github.com/AlanAyy/extraordinaire.git
```

You may notice that this will create a folder on your computer called `extraordinaire`. `cd` into this newly created folder.

- When we pulled the code we only pulled the `main` branch, so we need to pull the `beta` branch as well:

```bash
git checkout --track origin/beta
```

You can list all the branches currently on your local repository with the command `git branch`, and switch between branches with `git switch <branch-name>`.

## Working on a Jira ticket

### Create a new branch for the ticket

If you want to start working on a new ticket, you first need to create a new branch so you don't change any of the `main` or `beta` code once you push to the remote repo!!

- First, you should most likely branch out from `beta`, since that is what you'll eventually be merging your code into. You don't want to be branching out from some other branch! Ensure you're currently on the `beta` branch:

```bash
git switch beta
```

- Then, make a new branch and automatically switch to it with:

```bash
git checkout -b EX-N
```

where `N` corresponds to the number of the Jira ticket you plan to work on (located in the lower right-hand corner of the Jira ticket). You have now been switched to the `EX-N` branch, and you can begin working on your code. **Do not make any changes before you have made a new branch for them.**

### Unit testing!!!!!!!!!

Unfortunately, the successful completion of this project is going to hinge on comprehensive unit testing.

- First, we need to ensure you have the most up to date version of the Unity Testing Framework installed. While in the Unity Editor, go to `Window > Package Manager`. Near the top left corner of the popup window that opens is a little dropdown menu that has the options `Packages: Unity Registry`, `Packages: In Project`, `Packages: My Assets` and `Packages: Built-in`. Select `Packages: Unity Registry` and scroll down the list until you find `Test Framework`. Click on it and ensure it is fully up to date. As of the writing of this README the most recent version is 1.1.33. Now you can close the Package Manager.

- Next, open the Test Runner in `Window > General > Test Runner`. You'll see a breakdown of each test suite, and each of the test cases within each suite. You can use the buttons at the top of the Test Runner to run all of the tests, run only selected tests, rerun the failed tests, or clear the results of the previous run.

The tests are located in the `Assets/Tests` folder. This folder contains one test file for each "test suite". Each file contains a public class with the same name as the file, and one or more tests implemented as regular methods except that each starts with a compiler flag `[Test]`.

- If you are working on an existing component of the game, open the existing suite file corresponding to the component. If you are working on a new component, create a new suite file and copy over the contents of one of the existing files except for the tests themselves.

You should write tests **before** you even start writing the code that the tests are testing! That sounds counter-intuitive, but if you write tests intentionally to make them fail first, and *then* write the code to fix them and get them passing, not only are you ensuring your code is thoroughly tested from the beginning, but it forces you to think about the design of your code before you recklessly jump right into writing it.

### Pushing your changes

Once you've finished a commit, push it to the remote repo on your new branch:

```
git add <list of files separated by spaces, or . for all files>
git commit -m "A descriptive commit message"
git push -u origin EX-N
```

> Note that you only need to use `git push -u origin <branch-name>` the first time you push to remote from a new branch. Every time after that, you can simply use `git push`.

### Making a pull request

Once you're satisfied with the changes you made on your branch, you can make a pull request to initiate a code review.

- Go to the remote repository and navigate to your `EX-N` branch. Along the top, above the list of files, should be a note that says "EX-N had recent pushes" and a green button that says "Compare & pull request". Great! If not, there should be a note that says "This branch is X commits ahead of main", and you can click on "Open pull request" under the "Contribute" dropdown on that note.

- First, ensure you are requesting a pull to `beta`, not `main`. Underneath the "Comparing changes" header, there should be a bar that specifies the base and the compare branches. The base should be the `beta` branch, not the `main` branch, and the compare branch should be your `EX-N` branch.

- Give your PR a title, something short and sweet like "Resolve EX-N".

- Fill out the description, explaining what your code is doing/changing about the current game, how your code solves the ticket `EX-N`, etc.

- Optionally, assign one or more reviewers along the right hand side of the page if you want specific team members to review your PR.

- Ensure all of the tests are passing (pull requests won't be merged unless the CI pipeline passes, indicated by a bunch of green check marks)

- And finally, create your pull request. Congrats! Your PR will be reviewed by a variety of team members and must be approved by two of them to be merged into the `beta` branch.

### Reviewing a pull request

We want to do our due diligence in making sure that code we're accepting into `beta` and eventually `main` is sound. So on top of looking at the code changes themselves and asking the initiator of the PR any questions you may have, you should pull the branch into your own local repository with `git checkout --track origin/EX-N` and play test it to make sure it does what the PR says it does. Sometimes code that works on one machine mysteriously doesn't work on another.

If you encounter any bugs, errors, warnings, improper formatting or typos, or simply something that you believe isn't written in the best way, submit a review on the PR explaining your concern. When you submit a review on a PR, you can either accept it, request changes, or simply comment on something without doing either. We don't want to accept any code into `beta` or `main` until all concerns from all team members are resolved.

When comments are left on PRs, it means that not everyone is satisfied with the code that is being proposed. This will generate a discussion from possibly multiple team members, hopefully including the initiator of the PR. A comment thread can be "resolved" either through a discussion ending in a consensus decision that the concern is unfounded, or additional commits to the PR which fix the concern (you can still commit to a branch and therefore a PR after it has been opened), in which case additional comments should be made referencing these commits and explaining how they resolve the concern.

Once all of the concerns have been resolved, and the PR has received two approvals from members of the team, it will be merged into `beta`. Congratulations!
