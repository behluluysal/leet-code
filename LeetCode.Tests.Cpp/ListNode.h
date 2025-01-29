#ifndef LISTNODE_H
#define LISTNODE_H

#include <vector>

struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
};

// Helper functions for testing
ListNode* createLinkedList(const std::vector<int>& values);
std::vector<int> linkedListToVector(ListNode* head);
void deleteLinkedList(ListNode* head);

// Actual Methods
// https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list
ListNode* deleteMiddle(ListNode* head);

// https://leetcode.com/problems/odd-even-linked-list
ListNode* oddEvenList(ListNode* head);

#endif // LISTNODE_H